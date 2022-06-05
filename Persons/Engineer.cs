using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramLAB_14
{
    public class Engineer : Employee
    {
        public int experience;
        //protected new string profession = "Инженер";
        public int Experience
        {
            get { return experience; }
            set { experience = value; }
        }
        public Engineer() : base()
        {
            experience = rnd.Next(1, 100);
        }

        public override void Init()
        {
            Experience = 5;
            Age = rnd.Next(100);
        }
        public Engineer(int age) : base(age)
        {

        }
        public Engineer(int age, string po) : base(age, po)
        {

        }
        public Engineer(int age, string po, string pr) : base(age, po, pr)
        {
            
        }

        public Engineer(int age, string po, string pr, int experience) : base(age, po, pr)
        {
            Experience = experience;
        }
        public override void ShowInfo()
        {
            Console.WriteLine($"Я человек, мой возраст: {age}, моя должность: {post} , моя профессия: {profession} и мой опыт работы: {experience}");
        }
        public void Show()
        {
            Console.WriteLine($"Я человек, мой возраст: {age}, моя должность: {post} , моя профессия: {profession} и мой опыт работы: {experience}");
        }
        public override string ToString()
        {
            return string.Format($"Я человек, мой возраст: {age}, моя должность: {post} , моя профессия: {profession} и мой опыт работы: {experience}");
        }

        public override object Clone()
        {
            return new Engineer(Age, Post, Profession, Experience);
        }

        public override bool Equals(object pers)
        {

            Engineer other = pers as Engineer;
            if (other == null)
                return false;

            if ((this.Age == other.Age) && (this.Post == other.Post) && (this.Profession == other.Profession) && (this.Experience == other.Experience))
                return true;
            else
                return false;

        }
        
        
    }
}
