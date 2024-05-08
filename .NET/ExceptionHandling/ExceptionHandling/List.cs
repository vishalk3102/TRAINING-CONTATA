using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    internal class List
    {
        static void main(string[] args)
        {
            List<int> num = new List<int>();
            num.Add(5);
            num.Add(8);
            num.Add(2);
            num.Add(5);
            num.Add(8);
            num.Add(9);
            num.Add(12);


            Console.WriteLine("The Element of List are :");
            foreach (var i in num)
            {
                Console.WriteLine(i);
            }

            num.RemoveAll(i => i == 5);

            Console.WriteLine("The Element of List After deleting all 5 are :");
            foreach (var i in num)
            {
                Console.WriteLine(i);
            }
        }
    }
}
