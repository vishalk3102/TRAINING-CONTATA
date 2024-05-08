using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoResetSynchronization
{
      internal class Program
    {
        static AutoResetEvent _are = new AutoResetEvent(true);
        static string fileContent;

        static void Main(string[] args)
        {
            new Thread(() => ReadFileContent()).Start();
            new Thread(() => WriteFileContent()).Start();


            Console.ReadKey();
        }

        static void ReadFileContent()
        {
            try
            {
                Console.WriteLine("Reading Content From File Started");
                _are.WaitOne();
                Thread.Sleep(1000);
                fileContent = File.ReadAllText("input.txt");
                Console.WriteLine("Reading Content From File Completed\n");
                _are.Set(); 
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void WriteFileContent()
        {
            Console.WriteLine("Waiting for File Content ");
            _are.WaitOne(); 
            Console.WriteLine("Writing Content of file started");
            Console.WriteLine($"File Content :\n {fileContent}");
            Console.WriteLine("Writing Content of file completed");
        }

    }
}


