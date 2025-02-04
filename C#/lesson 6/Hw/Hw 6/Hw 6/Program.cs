using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hw_6;

namespace Hw_6
{
    public class BankAccount
    {
        private decimal balance;
        public decimal Balance
        {
            get { return balance; }
            set
            {
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
        public override string ToString()
        {
            return $"Баланс: {Balance} грн";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
        BankAccount bankAccount = new BankAccount();
        bankAccount.Deposit(1000);
        bankAccount.Withdraw(500);
        bankAccount.Withdraw(600);

        Console.WriteLine(bankAccount);
        }
    }
}
