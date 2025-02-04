using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_6._3
{
    public class BankAccount
    {
        private decimal balance;
        public decimal Balance
        {
            get { return balance; }
            set {
                if (value < 0) Console.WriteLine("Balance Error");
                else balance = value;
            }
        }
        public void Deposit(decimal amount)
        {
            if (amount <= 0) Console.WriteLine("Amount Error");
            else
            {
                Balance += amount;
                Console.WriteLine($"Balance add {amount}");
            }
        }
        public void Withdraw(decimal amount)
        {
            if (amount <= 0) Console.WriteLine("Amount must bigger 0");
            else if (amount > Balance) Console.WriteLine("Insufficient funds");
            else
            {
                Balance -= amount;
                Console.WriteLine($"New balance: {Balance}");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount bankAccount = new BankAccount();
            bankAccount.Deposit(100);
            bankAccount.Withdraw(50);
            Console.WriteLine(bankAccount.Balance);
        }
    }
}
