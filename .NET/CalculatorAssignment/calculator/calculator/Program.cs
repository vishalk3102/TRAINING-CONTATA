using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    internal class Program
    {
        public void Add(int x, int y)
        {
            int ans = x+y;
            Console.WriteLine($"Addition of {x} and {y} : {ans}");
        }
        public void subtract(int x, int y)
        {
            int ans = x - y;
            Console.WriteLine($"Subtraction of {x} and {y} : {ans}");
        }
        public void Multiply(int x, int y)
        {
            int ans = x * y;
            Console.WriteLine($"Multiplication of {x} and {y} : {ans}");
        }
       
        public void Divide(int x, int y)
        {
          try
          {
                if(y==0)
                {
                   throw new DivideByZeroException();
                }
                double ans = (double)x / y;
                Console.WriteLine($"Division of {x} and {y} : {ans}");
            }
          catch (DivideByZeroException e)
          {
             Console.WriteLine(e.Message);
          }
        }
        static void Main(string[] args)
        {
            Console.Write("Enter X:");
            int x= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Enter Y:");
            int y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Program obj = new Program();
            obj.Add(x, y);
            obj.subtract(x, y);
            obj.Multiply(x, y);
            obj.Divide(x, y);
        }
    }
}
