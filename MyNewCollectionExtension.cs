using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramLAB_14
{
    public static class MyNewCollectionExtension
    {
        //Выборка
        static public IEnumerable<int> AllAnimalWeight(this MyLinkList<Person> collection)
        {
            var result = collection.Where(p => p.Age > 20).OrderBy(p => p.Age).Select(p => p.Age);
            return result;
        }

        ////Агрегирование
        //static public string WeightAgregate(this MyCollection<Animal> collection)
        //{
        //    var max = (collection.Select(p => p.Weight)).Max();
        //    var min = (collection.Select(p => p.Weight)).Min();
        //    var average = (collection.Select(p => p.Weight)).Average();

        //    return $" Максимальный вес: {max} \n Минимальный вес: {min} \n Средний вес: {average}";
        //}

        ////Сортировка
        //static public IEnumerable<string> SortColection(this MyCollection<Animal> collection)
        //{
        //    var result = collection.OrderBy(p => p.Weight).Select(p => p.ToString());
        //    return result;
        //}
    }
}
