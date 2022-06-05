using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramLAB_14
{
    public class Employee : Person 
    {
        //protected new string post = "Служащий";
        public string profession;
        public string Profession { get; set; }
        public Employee() : base()
        {
            profession = RandomString(5);
        }
        public override void Init()
        {
            profession = "";
            Age = rnd.Next(100);
        }
        public Employee(int age) : base(age)
        {
        }
        public Employee(int age, string p) : base(age, p)
        {          
        }
        public Employee(int age, string p, string s1) : base(age, p)
        {

            profession = s1;
        }
        public override void ShowInfo()
        {
            Console.WriteLine($"Я человек, мой возраст: {age}, моя должность: {post}, моя профессия: {profession}");
        }
        public void Show()
        {
            Console.WriteLine($"Я человек, мой возраст: {age}, моя должность: {post}, моя профессия: {profession}");
        }
        public override string ToString()
        {
            return string.Format($"Я человек, мой возраст: {age}, моя должность: {post}, моя профессия: {profession}");
        }

        public override object Clone()
        {
            return new Employee(Age, Post, Profession);
        }
        public override bool Equals(object pers)
        {

            Employee other = pers as Employee;
            if (other == null)
                return false;

            return
               (this.Age == other.Age) && (this.Post == other.Post) && (this.Profession == other.Profession);

        }

    }
}
