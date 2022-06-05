using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramLAB_14
{
    public class CreateNewExem 
    {
        public Person pers;
        public Worker work;
        public Employee empl;
        public Engineer engi;
        public int CountExem;

        public CreateNewExem()
        {
            
        }
        //public CreateNewExem(int age)
        //{
        //    pers = new Person(age);
        //    //work = new Worker(age);
        //    //empl = new Employee(age);
        //    //engi = new Engineer(age);
        //    //CountExem = 1;
        //}
        //public CreateNewExem(int age, string post)
        //{
        //    pers = new Person(age,post);
        //    //work = new Worker(age, post);
        //    //empl = new Employee(age, post);
        //    //engi = new Engineer(age, post);
        //    //CountExem = 2;
        //}
        //public CreateNewExem(int age, string post, string prof)
        //{                        
        //    empl = new Employee(age, post, prof);
        //    //engi = new Engineer(age, post, prof);
        //    //CountExem = 3;
        //}
        //public CreateNewExem(int age, string post, int disch)
        //{
        //    work = new Worker(age, post,disch);
        //    //CountExem = 4;
        //}
        //public CreateNewExem(int age, string post, string prof , int exp)
        //{
        //    engi = new Engineer(age, post, prof, exp);
        //    //CountExem = 5;
        //}
        public void NewExemus()
        {
            int age = ReadNumber("Введите возраст");
            Console.Write("Введите должность(служащи,рабочий,безработный и др): ");
            string post = Console.ReadLine();
            pers = new Person(age, post);
            CountExem = 1;
            int choice1 = 0;
            int choice2 = 0;
            Console.WriteLine("1. Ввести профессию\n2. Ввести разряд\n3. Закончить ввод");
            choice1 = MakeChoice(MaxChoice: 3, MinChoice: 1);
            switch (choice1)
            {
                case 1:
                    Console.Write("Введите профессию: ");
                    string prof = Console.ReadLine();
                    empl = new Employee(age, post, prof);
                    CountExem = 2;
                    Console.WriteLine("1. Ввести опыт работы\n2. Закончить ввод");
                    choice2 = MakeChoice(MaxChoice: 2, MinChoice: 1);
                    switch (choice2)
                    {
                        case 1:
                            int exp = ReadNumber("Введите опыт работы: ");
                            engi = new Engineer(age, post, prof, exp);
                            CountExem = 3;
                            break;
                        case 2:                                                       
                            break;
                    }
                    break;
                case 2:
                    int disch = ReadNumber("Введите разряд: ");
                    work = new Worker(age, post, disch);
                    CountExem = 4;
                    break;
                case 3: break;
            }
        }
        private static int MakeChoice(int MinChoice, int MaxChoice) // Ввод выбора команды (есть именованные параметры)
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
        private static int ReadNumber(string Message = "")
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
