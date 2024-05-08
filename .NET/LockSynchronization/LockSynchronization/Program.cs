using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LockSynchronization
{
    internal class Program
    {
        static Account AccountA = new Account(1, 2000);
        static Account AccountB = new Account(2, 2000);

        static void Main(string[] args)
        {
            new Thread(() => transferAmount(AccountB, AccountA, 200)).Start();
            new Thread(() => transferAmount(AccountA, AccountB, 500)).Start();
            Console.ReadKey();
        }

        static void transferAmount(Account fromAccount,Account toAccount,int amount)
        {
            Account firstLock=fromAccount.Id <toAccount.Id ?fromAccount:toAccount;
            Account secondLock = fromAccount.Id < toAccount.Id ? toAccount : fromAccount;

            lock(firstLock)
            {
                Thread.Sleep(2000);
                lock(secondLock) 
                {
                    fromAccount.balance -= amount;
                    toAccount.balance += amount;
                    Console.WriteLine($"\nRs.{amount} Transferred from {fromAccount.Id} to {toAccount.Id}");
                    Console.WriteLine($"Balance of Account {fromAccount.Id} : {fromAccount.balance}");
                    Console.WriteLine($"Balance of Account {toAccount.Id} : {toAccount.balance}");
                }
            }
        }
    }


    class  Account
    {
        public int Id{ get; set; }
        public decimal  balance{ get; set; }

        public Account(int id,decimal amount)
        {
            Id = id;
            balance = amount;
        }
    }
}
