using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramLAB_14
{
    public class Worker : Person
    {
        //protected new string post = " Рабочий ";

        public int discharge;
        public int Discharge
        {
            get { return discharge; }
            set { discharge = value; }
        }
        //public string profession;
        
        
        public Person BasePerson
        {
            get { return new Person(Age, Post); }
        }

        public Worker() : base()
        {
            discharge = rnd.Next(0,100);
        }
        public Worker(int ages)
        {
            Age = ages;
            post = "Рабочий";
            discharge = 7777;
        }
        public Worker(int ages, string posts)
        {
            Age = ages;
            Post = posts;
            
        }
        public Worker(int age, string p, int s1) : base(age, p)
        {
            Discharge = s1;
        }


        public override void Init()
        {
            Discharge = 5;
            Age = rnd.Next(100);
        }        
        
        public override void ShowInfo()
        {
            Console.WriteLine($"Я человек, мой возраст: {age}, моя должность: {post}, мой разряд: {discharge}");
        }
        public void Show()
        {
            Console.WriteLine($"Я человек, мой возраст: {age}, моя должность: {post}, мой разряд: {discharge}");
        }
        public override string ToString()
        {
            return string.Format($"Я человек, мой возраст: {age}, моя должность: {post}, мой разряд: {discharge}");
        }
        
        
        public override object Clone()
        {
            return new Worker(Age, Post, Discharge);
        }
        
        public override bool Equals(object pers)
        {

            Worker other = pers as Worker;
            if (other == null)
                return false;

            return
               (this.Age == other.Age) && (this.Post == other.Post) && (this.Discharge == other.Discharge);

        }
    }
   
}
