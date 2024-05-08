using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            Student st;
            st = new Student();

            try
            {
                Student st1 = null;
                int roll = st1.rollno;
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }

            st.ListWeek();
            st.LoadFile();
            st.IntToByte();

        }
    }

    public class Student
    {
        public int rollno { get; set; }

        public void ListWeek()
        {

            string[] list = new string[5];
            list[0] = "Sunday";
            list[1] = "Monday";
            list[2] = "Tuesday";
            list[3] = "Wednesday";
            list[4] = "Thursday";

            try
            {
                for (int i = 0; i <= 5; i++)
                {
                    Console.WriteLine(list[i].ToString());
                }
                Console.ReadLine();
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void IntToByte()
        {
            int num1, num2;
            byte result;

            num1 = 30;
            num2 = 60;
            try
            {
                result = Convert.ToByte(num1 * num2);
                Console.WriteLine("{0} x {1} = {2}", num1, num2, result);
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }

        public void LoadFile()
        {
            int counter = 0;
            StreamReader file = null;
            string ln;
            try
            {
                string textFile = "input11.txt";
                using (file = new StreamReader(textFile))
                {
                    while ((ln = file.ReadLine()) != null)
                    {
                        Console.WriteLine(ln);
                        counter++;
                    }
                    Console.WriteLine($"File has {counter} lines.");
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

        }

    }
}