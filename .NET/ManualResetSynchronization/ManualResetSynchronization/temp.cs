using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LockSynchronization
{
	internal class Program1
	{
		static Account AccountA = new Account(1, 2000);
		static Account AccountB = new Account(2, 2000);

		static void Main(string[] args)
		{
			new Thread(() => transferFromAtoB(AccountB, AccountA, 200)).Start();
			new Thread(() => transferFromBtoA(AccountA, AccountB, 200)).Start();
			Console.ReadKey();
		}

		static void transferFromAtoB(Account A, Account B, int amount)
		{
			console.writeLine($"Transaction Begins")

			A.balance -= amount;
			B.balance += amount;

			Console.WriteLine($"Rs.{amount} Transferred from Account A to Account B");
			Console.WriteLine($"Balance of Account A : {A.balance}");
			Console.WriteLine($"Balance of Account B : {B.balance}");
			console.writeLine($"Transaction Ends")
		}
		static void transferFromBtoA(Account A, Account B, int amount)
		{
			console.writeLine($"Transaction Begins")

			B.balance -= amount;
			A.balance += amount;

			Console.WriteLine($"Rs.{amount} Transferred from Account B to Account A");
			Console.WriteLine($"Balance of Account A : {A.balance}");
			Console.WriteLine($"Balance of Account B : {B.balance}");
			console.writeLine($"Transaction Ends")
		}

	}


	class Account
	{

		public int Id { get; set; }
		public decimal balance { get; set; }

		public Account(int id, decimal amount)
		{
			Id = id;
			balance = amount;
		}
	}
}
