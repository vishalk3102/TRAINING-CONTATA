using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Thread thread1 = new Thread(countUp);
            Thread thread2 = new Thread(countDown);

            thread1.Start();
            thread2.Start();

        }
        private static void countUp()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Thread 1 : {i}");
                Thread.Sleep(1000);
            }
        }
        private static void countDown()
        {
            for (int i = 10; i >= 0; i--)
            {
                Console.WriteLine($"Thread 2 : {i}");
                Thread.Sleep(1000);
            }
        }
    }
}
