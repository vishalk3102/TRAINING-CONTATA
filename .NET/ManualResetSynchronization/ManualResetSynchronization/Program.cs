using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ManualResetSynchronization
{
    internal class Program
    {

        static ManualResetEvent _mre = new ManualResetEvent(false);
        static ManualResetEvent _mre1 = new ManualResetEvent(false);
        static string fileContent;

        static void Main(string[] args)
        {
            Thread threadRead = new Thread(() => ReadFileContent());
            Thread threadWrite = new Thread(() => WriteFileContent());
            threadRead.Start();
            threadWrite.Start();
            _mre1.Set();
            threadRead.Join();
            threadWrite.Join();


            Console.WriteLine("Program end");

            Console.ReadKey();
        }

        static void ReadFileContent()
        {
            try
            {
                Console.WriteLine("Reading Content From File Started");
                _mre1.WaitOne();
                _mre1.Reset();
                Thread.Sleep(1000);
                fileContent = File.ReadAllText("input.txt");
                Console.WriteLine("Reading Content From File Completed\n");
                _mre.Set();
            }
            catch(FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void WriteFileContent()
        {
           Console.WriteLine("Waiting for File Content ");
            _mre.WaitOne();
            _mre.Reset();
           Console.WriteLine("Writing Content of file started");
           Console.WriteLine($"File Content :\n {fileContent}");
           Console.WriteLine("Writing Content of file completed");
        }

    }
}
