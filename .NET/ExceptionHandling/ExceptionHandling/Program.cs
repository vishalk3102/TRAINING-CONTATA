using System;
using System.Collections.Generic;
using System.IO;

namespace ExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Dictionary<int,List<string>> dictionary= new Dictionary<int, List<String>>();
           dictionary.Add(1, new List<string>{ "Dheeraj"});
           dictionary.Add(2, new List<string>{ "Rajesh","Suresh" ,"Mukesh" });
           dictionary.Add(3, new List<string>{ "Tina"});
           dictionary.Add(4, new List<string>{ "Alisha"});
           dictionary.Add(5, new List<string>{ "Jennifer"});
           dictionary.Add(6, new List<string>{ "Nadia"});


            Console.WriteLine("Unsorted Dictionary Key Value Pairs");
            foreach (var item in dictionary)
            {
                Console.Write($"key :{item.Key}, Value :");
                foreach(var value in item.Value)
                {
                    Console.Write($"{value},");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n\n");

            Dictionary<int,string> sortedDictionary = new Dictionary<int, string>();
            foreach (var item in dictionary)
            {
                if(!sortedDictionary.ContainsKey(item.Key))
                {
                    sortedDictionary.Add(item.Key, item.Value[0]);
                }
            }

            Console.WriteLine("Sorted Dictionary Key Value Pairs");
            foreach (var item in sortedDictionary)
            {
                Console.WriteLine($"Key :{item.Key} , Value :{item.Value}");
            }
        }
    }
}



