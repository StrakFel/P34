using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Banking_System
{
    class Account // Класс банковского счета
    {
        public int ID { get; } // Уникальный айди счета
        public double Balance { get; private set; } // Баланс, который можно только посмотреть
        private object balanceLock = new object(); // Обьект блокировки для синхронизации

        public Account(int id, double initialBalance)
        {
            ID = id;
            Balance = initialBalance;
        }

        public bool Withdraw(double amount)
        {
            lock (balanceLock) // Блокировка доступа к балансу
            {
                if (Balance >= amount && Balance >= 2000) // Нельзя снимать если больше 2000
                {
                    Balance -= amount;
                    return true;
                }
                return false;
            }
        }

        public void Deposit(double amount)
        {
            lock (balanceLock)
            {
                Balance += amount;
            }
        }

        public double GetBalance()
        {
            lock (balanceLock)
            {
                return Balance;
            }
        }

        public bool TransferTo(Account target, double amount)
        {
            bool success = false;

            // Что бы избежать взаимных блокировок
            object firstLock = this.ID < target.ID ? this : target;
            object secondLock = this.ID < target.ID ? target : this;

            lock (firstLock)
            {
                lock (secondLock)
                {
                    if (this.Balance >= amount)
                    {
                        this.Balance -= amount;
                        target.Balance += amount;
                        success = true;
                    }
                }
            }
            return success;
        }
    }
    // Класс банка, который делает логи и хранит счета
    class Bank
    {
        public List<Account> Accounts { get; private set; } = new List<Account>();
        private object logLock = new object(); // Блокировка логирования
        private Random rnd = new Random();

        public Bank()
        {
            for (int i = 1; i <= 5; i++)
            {
                double initialBalance = rnd.Next(5000, 10001); // Делает рандомно значение баланса от 5000 до 10000
                Accounts.Add(new Account(i, initialBalance));
            }
        }

        public void Log(string message)
        {
            lock (logLock)
            {
                Console.WriteLine(message);
                File.AppendAllText("bank_log.txt", message + "\n");
            }
        }
    }
    // Класс клиента, который работает в отдельном потоке
    class Client
    {
        private Bank bank;
        private int clientId;
        private bool isVip;
        private static SemaphoreSlim semaphore = new SemaphoreSlim(3); // Только 3 клиента могут взаимодествовать с банком

        public Client(Bank bank, int clientId, bool isVip = false)
        {
            this.bank = bank;
            this.clientId = clientId;
            this.isVip = isVip;
        }

        public void Run()
        {
            Thread thread = new Thread(() =>
            {
                Random rnd = new Random();
                DateTime endTime = DateTime.Now.AddSeconds(60); // Раобота потка 60 секунд

                while (DateTime.Now < endTime)
                {
                    semaphore.Wait(); // Ограничение до 3 потоков

                    try
                    {
                        PerformRandomOperation(rnd);
                    }
                    finally
                    {
                        semaphore.Release(); // Освобождение слота
                    }

                    Thread.Sleep(rnd.Next(1000, 3001)); // Рандомная задержка от 1 до 3 секунд
                }
            });

            thread.IsBackground = true;
            thread.Priority = isVip ? ThreadPriority.AboveNormal : ThreadPriority.Normal;
            thread.Start();
        }

        private void PerformRandomOperation(Random rnd)
        {
            int op = rnd.Next(0, 4); // Рандомная операция от 0 до 3
            int accountIndex = rnd.Next(bank.Accounts.Count);
            Account account = bank.Accounts[accountIndex];

            // 10% шанс на ошибку сервера
            if (rnd.Next(0, 10) == 0)
            {
                bank.Log($"[Клієнт {clientId}] ПОМИЛКА СЕРВЕРА! Операція скасована.");
                return;
            }

            switch (op)
            {
                case 0: // Снятие
                    double withdrawAmount = rnd.Next(100, 3001);
                    if (account.Withdraw(withdrawAmount))
                        bank.Log($"[Клієнт {clientId}] Зняв {withdrawAmount} грн з рахунку #{account.ID}. Баланс: {account.GetBalance()} грн");
                    else
                        bank.Log($"[Клієнт {clientId}] Не вдалося зняти кошти з рахунку #{account.ID}. Невистачає коштів.");
                    break;
                case 1: // Пополнение
                    double depositAmount = rnd.Next(100, 5001);
                    account.Deposit(depositAmount);
                    bank.Log($"[Клієнт {clientId}] Поповнив рахунок #{account.ID} на {depositAmount} грн. Баланс: {account.GetBalance()} грн");
                    break;
                case 2: // Перевод
                    int targetIndex = rnd.Next(bank.Accounts.Count);
                    while (targetIndex == accountIndex)
                        targetIndex = rnd.Next(bank.Accounts.Count);
                    Account target = bank.Accounts[targetIndex];
                    double transferAmount = rnd.Next(500, 7001);
                    if (account.TransferTo(target, transferAmount))
                        bank.Log($"[Клієнт {clientId}] Переказав {transferAmount} грн з #{account.ID} на #{target.ID}. Баланс #{account.ID}: {account.GetBalance()} грн, #{target.ID}: {target.GetBalance()} грн");
                    else
                        bank.Log($"[Клієнт {clientId}] Не вдалося переказати з #{account.ID} на #{target.ID}.");
                    break;
                case 3: // Запрос баланса
                    bank.Log($"[Клієнт {clientId}] Запитав баланс рахунку #{account.ID}: {account.GetBalance()} грн");
                    break;
            }
        }
    }
    // Класс таймера для банка, делает автосохранения и комисии
    class BankTimers
    {
        private Bank bank;

        public BankTimers(Bank bank)
        {
            this.bank = bank;

            var saveTimer = new System.Threading.Timer(_ => Save(), null, 0, 10000); // Автосохранения каждые 10 секунда
            var feeTimer = new System.Threading.Timer(_ => Fee(), null, 0, 15000); // Комисия каждые 15 секунд
        }

        private void Save()
        {
            bank.Log("**Автозбереження** Всі рахунки збережено у bank_log.txt.");
        }

        private void Fee()
        {
            foreach (var account in bank.Accounts)
            {
                double fee = account.GetBalance() * 0.01; // Комисия 1%
                account.Withdraw(fee);
            }

            bank.Log("**Автоматична комісія** з кожного рахунку знято 1%.");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Bank bank = new Bank(); // Создание банка
            BankTimers timers = new BankTimers(bank); // Запуск таймера

            //Запуск 5 клиентов, 2 и 5 клиенты - випы
            for (int i = 1; i <= 5; i++)
            {
                bool isVip = (i == 2 || i == 5);
                new Client(bank, i, isVip).Run();
            }

            Thread.Sleep(60000); // Программа работает 60 секунд

            // Вывод финальных балансов
            Console.WriteLine("Час вичерпано. Фінальні баланси рахунків:");
            foreach (var account in bank.Accounts)
            {
                Console.WriteLine($"#{account.ID}: {Math.Floor(account.GetBalance())} грн");
            }

            Console.WriteLine("Роботу завершено!");
        }
    }
}
