using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static calculatorDelegates.Program;



namespace calculatorDelegates
{

    internal class Program
    {
        public delegate  void CalculatorDelegate(int x, int y);

         public static void Main(string[] args)
        {
            Console.Write("\nEnter X:");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter Y:");
            int y = Convert.ToInt32(Console.ReadLine());

            while (true)
            {
                Console.WriteLine("\nCalculator Menu ");
                Console.WriteLine("1. Addition");
                Console.WriteLine("2. Subtraction");
                Console.WriteLine("3. Multiply");
                Console.WriteLine("4. Division");
                Console.WriteLine("5. Exit");
                Console.Write("Enter the option :");
                int op = Convert.ToInt32(Console.ReadLine());

                CalculatorDelegate obj;

                switch (op)
                {
                    case 1:
                        obj = new CalculatorDelegate(Calculator.Add);
                        obj(x, y);
                        break;
                    case 2:
                        obj = new CalculatorDelegate(Calculator.subtract);
                        obj(x, y);
                        break;
                    case 3:
                        obj = new CalculatorDelegate(Calculator.Multiply);
                        obj(x, y);
                        break;
                    case 4:
                        obj = new CalculatorDelegate(Calculator.Divide);
                        obj(x, y);
                        break;
                    case 5:
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Wrong Option");
                        break;
                }
            }
        }
    }

    public class Calculator
    {
        public static void Add(int x, int y)
        {
            int ans = x + y;
            Console.WriteLine($"\nAddition of {x} and {y} : {ans}\n");
        }
        public static void subtract(int x, int y)
        {
            int ans = x - y;
            Console.WriteLine($"\nSubtraction of {x} and {y} : {ans}\n");
        }
        public static void Multiply(int x, int y)
        {
            int ans = x * y;
            Console.WriteLine($"\nMultiplication of {x} and {y} : {ans}\n");
        }

        public static void Divide(int x, int y)
        {
            try
            {
                if (y == 0)
                {
                    throw new DivideByZeroException();
                }
                double ans = (double)x / y;
                Console.WriteLine($"\nDivision of {x} and {y} : {ans}\n");
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
