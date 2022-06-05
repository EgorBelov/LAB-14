using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramLAB_14
{
    public class Program
    {
        public static Queue<List<Person>> PersonQueue { get; set; }
        public static Random Random { get; set; } = new Random();
        
        public static List<Person> CreatePersonList()
        {
            List<Person> list = new List<Person>();
            for (int i=0; i<7; i++)
            {
                int rand_cl = Random.Next(0, 4); //рандомайзер на выбор класса для создания элемента массива
                Person p = new Person();
                if (rand_cl == 0)
                {
                    p= new Person();
                }
                if (rand_cl == 1)
                {
                   p = new Engineer();
                }
                if (rand_cl == 2)
                {
                   p = new Employee();
                }
                if (rand_cl == 3)
                {
                    p = new Worker();
                }

                list.Add(p);
            }
            return list;
        }
         public static Queue<List<Person>> CreatePersonQueue()
         {
            Queue<List<Person>> list = new Queue<List<Person>>();
            for (int i=0; i<3; i++)
            {
                List<Person> p = CreatePersonList();
                list.Enqueue(p);
            }
            return list;
         }
        public static void PrintQueue(Queue<List<Person>> list)
        {
            int i = 1;
            foreach(List<Person> p in list)
            {
                Console.WriteLine($"ЦЕХ #{i}");
                foreach(var item in p)
                {
                    Console.WriteLine(item);
                }
                i++;
            }
        }

        //Агрегирование
        public static void MinMaxAvgOfQueue1(Queue<List<Person>> list)
        {
            Console.WriteLine("Метод расширения");
            int i = 1;
            List<int> listMax = new List<int>();
            List<int> listMin = new List<int>();
            List<double> listAvg = new List<double>();
            int maxAge;
            double avgAge;
            int minAge;
            foreach (var p in list)
            {
                maxAge = p.Max<Person>(x => x.Age);
                minAge = p.Min<Person>(x => x.Age);
                avgAge = p.Average<Person>(x => x.Age);
                Console.WriteLine($"Самый большой возраст в цеху {i}: {maxAge}");
                Console.WriteLine($"Самый маленький возраст в цеху {i}: {minAge}");
                Console.WriteLine($"Самый средний возраст в цеху {i}: {avgAge}");
                listMax.Add(maxAge);
                listMin.Add(minAge);
                listAvg.Add(avgAge);
                i++;
            }
            maxAge = listMax.Max<int>(x => x);
            minAge = listMin.Min<int>(x => x);
            avgAge = listAvg.Average<double>(x => x);
            Console.WriteLine($"Самый большой возраст: {maxAge}");
            Console.WriteLine($"Самый маленький возраст: {minAge}");
            Console.WriteLine($"Самый средний возраст: {avgAge}");
        }
        public static void MinMaxAvgOfQueue2(Queue<List<Person>> list)
        {
            Console.WriteLine("LinQ");
            int i = 1;
            List<int> listMax = new List<int>();
            List<int> listMin = new List<int>();
            List<double> listAvg = new List<double>();
            int maxAge;
            double avgAge;
            int minAge;
            foreach (var p in list)
            {
                maxAge = (from item in p select item.Age).Max();
                minAge = (from item in p select item.Age).Min();
                avgAge = (from item in p select item.Age).Average();
                Console.WriteLine($"Самый большой возраст в цеху {i}: {maxAge}");
                Console.WriteLine($"Самый маленький возраст в цеху {i}: {minAge}");
                Console.WriteLine($"Самый средний возраст в цеху {i}: {avgAge}");
                listMax.Add(maxAge);
                listMin.Add(minAge);
                listAvg.Add(avgAge);
                i++;
            }
            maxAge = (from item in listMax select item).Max();
            minAge = (from item in listMin select item).Min();
            avgAge = (from item in listAvg select item).Average();
            Console.WriteLine($"Самый большой возраст: {maxAge}");
            Console.WriteLine($"Самый маленький возраст: {minAge}");
            Console.WriteLine($"Самый средний возраст: {avgAge}");
        }
        
        //Подсчет
        public static int CountWorker(Queue<List<Person>> list)
        {
            int count = (from cex in list
                         from person in cex
                         where ((person is Worker) && (((Worker)person).Age > 50))
                         select (Worker)person).Count();
            return count;
        }

        //Выборка
        public static void SearchNameOfAge50(Queue<List<Person>> list)
        {
            Console.WriteLine("LINQ");
            var llist = (from cex in list
                         from person in cex
                         where (person.Age == 50)
                         orderby person
                         select person);
            foreach(var l in llist)
            {
                Console.WriteLine(l);
            }
        }

        //Работа над множеством
        public static void WorkOnSet(Queue<List<Person>> list)
        {
            Console.WriteLine("LINQ");
            var llist = (from person in list.ToArray()[0]
                         where (person is Employee)
                         select person.Post).ToList().Union(
                         from person in list.ToArray()[1]
                         where (person is Employee)
                         select person.Post).ToList();
            Console.WriteLine("Объединение post");
            llist.ForEach(person => Console.WriteLine(person));
            
            var llist1 = (from person in list.ToArray()[0]
                     where (person is Employee)
                     select person.Age).ToList().Intersect(
                         from person in list.ToArray()[1]
                         where (person is Employee)
                         select person.Age).ToList();
            Console.WriteLine();
            Console.WriteLine("Пересечение age");
            if (llist1.Count > 0)
            llist1.ForEach(person => Console.WriteLine(person));
            else Console.WriteLine("Одинаковых возрастов нет");
        }


        //Группировка
        public static void GroupByType(Queue<List<Person>> list)
        {
            Console.WriteLine("LINQ");
            var res = from person in list.ToArray()[0] group person by person.GetType();
            foreach (IGrouping<Type, Person> g in res)
            {
                Console.WriteLine(g.Key);
                foreach (var e in g)
                    Console.WriteLine(e);
                Console.WriteLine();
            }

        }
        static void Main(string[] args)
        {
            PersonQueue = CreatePersonQueue();
            PrintQueue(PersonQueue);

            MyMethods.PrintNext();

            Console.WriteLine("ВЫБОРКА ---- Возраст равен 50");
            SearchNameOfAge50(PersonQueue);
            PersonQueue.SearchNameOfAge50();

            MyMethods.PrintNext();

            Console.WriteLine("АГРЕГИРОВАНИЕ ---- Самый большой возраст в каждом цеху");
            Console.WriteLine();
            MinMaxAvgOfQueue1(PersonQueue);
            Console.WriteLine();
            MinMaxAvgOfQueue2(PersonQueue);

            MyMethods.PrintNext();

            Console.WriteLine("ПОДСЧЕТ ---- Количество Worker с возрастом больше 50");
            Console.WriteLine();
            Console.WriteLine($"LINQ: {CountWorker(PersonQueue)}");
            Console.WriteLine();
            Console.WriteLine($"Метод расширения: {PersonQueue.CountPerson()}");

            MyMethods.PrintNext();

            Console.WriteLine("РАБОТА НАД МНОЖЕСТВОМ ---- Employee в цехе 1 и 2");
            Console.WriteLine();
            WorkOnSet(PersonQueue);
            Console.WriteLine();
            PersonQueue.WorkOnSet();

            MyMethods.PrintNext();

            Console.WriteLine("ГРУППИРОВКА ---- по типу");
            Console.WriteLine();
            GroupByType(PersonQueue);
            Console.WriteLine();
            PersonQueue.GroupByType();

            MyMethods.PrintNext();

            Console.WriteLine("ЧАСТЬ 2");
            Console.WriteLine();
            var firstCollection = new MyLinkList<Person>(5);
            firstCollection.Print();
            Console.WriteLine();
            foreach(var item in firstCollection)
            {
                Console.WriteLine(item);
            }
            
            firstCollection.AllAnimalWeight();
        }
        
    }

    public static class MyExtension
    {
        public static int CountPerson(this Queue<List<Person>> list)
        {
            int count = list
                 .SelectMany(cex => cex
                     .Where(person => ((person is Worker) && (((Worker)person).Age > 50))).ToList()).Count();
            return count;
        }
        public static void SearchNameOfAge50(this Queue<List<Person>> list)
        {
            Console.WriteLine("Метод расширения");
            var llist = list
                 .SelectMany(cex => cex
                     .Where(person => person.Age == 50));
            
            foreach (var l in llist)
            {
                Console.WriteLine(l);
            }
        }
        public static void WorkOnSet(this Queue<List<Person>> list)
        {
            Console.WriteLine("Метод расширения");
            var llist = list.ToArray()[0]                 
                     .Where(person => person is Employee).ToList().Union(
                        list.ToArray()[1]
                     .Where(person => person is Employee).ToList());
            Console.WriteLine("Объединение post");
            foreach (var l in llist)
            {
                Console.WriteLine(l.post);
            }
            var llist1 = list.ToArray()[0]
                     .Where(person => person is Employee).ToList().Intersect(
                        list.ToArray()[1]
                     .Where(person => person is Employee).ToList());
            Console.WriteLine();
            Console.WriteLine("Объединение post");
            if (llist1.Count() > 0)
            {
                foreach (var l in llist1)
                {
                    Console.WriteLine(l.post);
                }
            }
            else Console.WriteLine("Одинаковых возрастов нет");
            
        }

        public static void GroupByType(this Queue<List<Person>> list)
        {
            Console.WriteLine("Метод расширения");
            var res = list.ToArray()[0].GroupBy(person => person.GetType());
            foreach (IGrouping<Type, Person> g in res)
            {
                Console.WriteLine(g.Key);
                foreach (var e in g)
                    Console.WriteLine(e);
                Console.WriteLine();
            }
        }

    }
}
