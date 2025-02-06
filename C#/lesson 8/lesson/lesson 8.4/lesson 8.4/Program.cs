using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_8._4
{
    public class BankAccount
    {
        public string AccountNumber { get; }
        public double Balance { get; protected set; }

        public BankAccount(string accountNumber, double initialBalance)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
        }

        public virtual void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"Deposited {amount:F2}. New balance: {Balance:F2}");
            }
        }

        public virtual bool Withdraw(double amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"Withdrawn {amount:F2}. New balance: {Balance:F2}");
                return true;
            }
            Console.WriteLine("Insufficient funds or invalid amount.");
            return false;
        }
    }

    public interface ICreditAccount
    {
        void RequestCredit(double amount);
    }

    public interface ISavingsAccount
    {
        void AddInterest(double interestRate);
    }

    public class CreditAccount : BankAccount, ICreditAccount
    {
        public double CreditLimit { get; }

        public CreditAccount(string accountNumber, double initialBalance, double creditLimit)
            : base(accountNumber, initialBalance)
        {
            CreditLimit = creditLimit;
        }

        public void RequestCredit(double amount)
        {
            if (amount > 0 && amount <= CreditLimit)
            {
                Balance += amount;
                Console.WriteLine($"Credit approved: {amount:F2}. New balance: {Balance:F2}");
            }
            else
            {
                Console.WriteLine("Credit request denied: amount exceeds credit limit.");
            }
        }
    }

    public class SavingsAccount : BankAccount, ISavingsAccount
    {
        public SavingsAccount(string accountNumber, double initialBalance)
            : base(accountNumber, initialBalance)
        {
        }

        public void AddInterest(double interestRate)
        {
            if (interestRate > 0)
            {
                double interest = Balance * (interestRate / 100);
                Balance += interest;
                Console.WriteLine($"Interest added: {interest:F2}. New balance: {Balance:F2}");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            List<BankAccount> accounts = new List<BankAccount>
        {
            new CreditAccount("CA123", 1000, 500),
            new SavingsAccount("SA456", 2000)
        };

            foreach (var account in accounts)
            {
                Console.WriteLine($"Account {account.AccountNumber} - Balance: {account.Balance:F2}");
                account.Deposit(500);
                account.Withdraw(300);

                if (account is ICreditAccount creditAcc)
                {
                    creditAcc.RequestCredit(400);
                }
                else if (account is ISavingsAccount savingsAcc)
                {
                    savingsAcc.AddInterest(5);
                }
            }
        }
    }
}
