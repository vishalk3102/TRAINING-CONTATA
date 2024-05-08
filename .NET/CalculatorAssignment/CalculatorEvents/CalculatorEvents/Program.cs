using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorEvents
{
    internal class Program
    {
        public static void Addition(int result)
        {
            Console.WriteLine($"\nAddition Result :{result}\n");
        }
        public static void Subtraction(int result)
        {
            Console.WriteLine($"\nSubtraction  Result :{result}\n");

        }
        public static void Multiplication(int result)
        {
            Console.WriteLine($"\nMultiplication  Result :{result}\n");

        }
        public static void Division(double result)
        {
            Console.WriteLine($"\nDivision  Result :{result}\n");

        }

        public static void Main(string[] args)
        {
            Console.Write("\nEnter X:");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter Y:");
            int y = Convert.ToInt32(Console.ReadLine());

            Calculator cal = new Calculator();
            cal.AdditionEvent += Addition;
            cal.SubtractionEvent += Subtraction;
            cal.MultiplicationEvent += Multiplication;
            cal.DivisionEvent += Division;




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


                switch (op)
                {
                    case 1:
                        cal.Add(x, y);
                        break;
                    case 2:
                        cal.subtract(x, y);
                        break;
                    case 3:
                        cal.Multiply(x, y);
                        break;
                    case 4:
                        cal.Divide(x, y);
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
        public delegate void AdditionHandler(int result);
        public delegate void SubtractionHandler(int result);
        public delegate void MultiplicationHandler(int result);
        public delegate void DivisionHandler(double result);


        public event AdditionHandler AdditionEvent;
        public event SubtractionHandler SubtractionEvent;
        public event MultiplicationHandler MultiplicationEvent;
        public event DivisionHandler DivisionEvent;

        public  void Add(int x, int y)
        {
            int ans = x + y;
            AdditionEvent?.Invoke(ans);
        }
        public void subtract(int x, int y)
        {
            int ans = x - y;
            SubtractionEvent?.Invoke(ans);
        }
        public void Multiply(int x, int y)
        {
            int ans = x * y;
            MultiplicationEvent?.Invoke(ans);
        }

        public void Divide(int x, int y)
        {
            try
            {
                if (y == 0)
                {
                    throw new DivideByZeroException();
                }
                double ans = (double)x / y;
                DivisionEvent?.Invoke(ans);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
