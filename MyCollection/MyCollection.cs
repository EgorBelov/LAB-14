using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramLAB_14
{
    public class MyCollection<T>
        where T : ICloneable, new ()// кольцевой связный список
    {
        public MyLinkList<T> col = new MyLinkList<T>();

        public MyCollection()
        {
            col = null;
        }

        internal object ToArray()
        {
            throw new NotImplementedException();
        }

        internal IEnumerable<object> SelectMany(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        public MyCollection(int capacity)
        {
            for (int i = 0; i < capacity; i++)
            {
                T temp = new T();
                
                col.Add(temp);
            }
            
        }

        internal object Where(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }

        internal object Select(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        public MyCollection(MyLinkList<T> col1)
        {
            col = col1.Clone();
            
        }
        
        public MyCollection( MyCollection<T> col2 )
        {
            
            col = (MyLinkList<T>)col2.col.Clone();
        }

        internal IEnumerable<object> OrderBy(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        public void Print() 
        {
           if (col == null)
           {
                Console.WriteLine("Коллекция пустая");
           }
           else
            
                foreach (var item in col)
                {
                    Console.WriteLine(item);
                }                                                    
        }

        
        public object Clone()
        {
            return new MyCollection<T>(this.col);
        }
        public object ShallowCopy()
        {
            return MemberwiseClone();
        }
    }
}
