using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramLAB_14
{
    internal class MyMethods
    {
        public static void WriteRed(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void WriteGreen(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public static void WriteBlue(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public static void PrintNext()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine();

            Console.ResetColor();
        }


        public static void Exit()
        {
            MyMethods.WriteGreen("Нажмите чтобы закончить");
            Console.ReadKey();
            Console.Clear();    
        }
      
        public static int MakeChoice(int MinChoice, int MaxChoice) // Ввод выбора команды (есть именованные параметры)
        {
            string buf; bool ok1; int number = 0; bool ok = false;
            while (!ok)
            {
                do
                {
                    buf = Console.ReadLine();
                    ok1 = int.TryParse(buf, out number);
                    if (!ok1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Ошибка выбора"); ; Console.ResetColor();
                    }
                } while (!ok1);

                if ((number >= MinChoice) && (number <= MaxChoice)) ok = true;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Ошибка выбора"); ; Console.ResetColor();
                    ok = false;
                }
            }
            return number;
        }
        public static int ReadNumber(string Message = "")
        {
            Console.Write(Message + " "); string buf; bool ok; int n = 0;
            do
            {
                buf = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Red;
                ok = int.TryParse(buf, out n);
                if ((!ok) || (n < 0)) Console.WriteLine("Данные введены не верно");
                Console.ResetColor();
            } while ((!ok) || (n < 0));
            return n;
        }

    }
}
