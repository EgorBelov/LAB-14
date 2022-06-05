using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramLAB_14
{
    public class MyNewCollection<T>: MyLinkList<T> where T : ICloneable, new()
    {
        public string Name { get; set; } // название коллекции
        public int Length { get { return count; } } // ее длина
        
        //конструкторы класса
        public MyNewCollection(string name)
        {
            head = null;
            tail = null;
            Name = name;
        }

        public MyNewCollection(int capacity, string name)
        {
            for (int i = 0; i < capacity; i++)
            {
                T temp = new T();

                Add(temp);
            }
            Name = name;
        }



        public delegate void CollectionHandler(object source, CollectionHandlerEventArgs args); //делегат                                                                                               
        public event CollectionHandler CollectionCountChanged;//происходит при добавлении нового элемента или при удалении элемента из коллекции             
        public event CollectionHandler CollectionReferenceChanged;//происходит когда объекту коллекции присваивается новое значение


        public Node<T> this[int index] //итератор
        {
            get
            {
                if (index < Count && index >= 0)
                {
                    Node<T> p = this.head;
                    for (int i = 0; i < index; i++)
                    {
                        p = p.Next;
                    }
                    return p;
                }
                else
                    return null;
            }
            set
            {
                if (index < Count && index >= 0)
                {
                    Node<T> p = this.head;
                    for (int i = 0; i < index; i++)
                    {
                        p = p.Next;
                    }
                    CollectionReferenceChanged?.Invoke(this, new CollectionHandlerEventArgs(value, $"\n\t{this[index]} изменен на {value} по индексу {index}"));
                    p.Data = value.Data;
                }
            }
        }

        public override string ToString()
        {
            return Name;
        }

        public override void Add(T data) //Добавление элемента и событие
        {           
            Node<T> node = new Node<T>(data);
            // если список пуст
            if (head == null)
            {
                head = node;
                tail = node;
                tail.Next = head;
                CollectionCountChanged?.Invoke(this, new CollectionHandlerEventArgs(data, $"\n\tДобавлен {data} "));
            }
            else
            {
                node.Next =head;
                tail.Next = node;
                tail = node;
                CollectionCountChanged?.Invoke(this, new CollectionHandlerEventArgs(data, $"\n\tДобавлен {data} "));
            }
            count++;
        }

        public override void AddDefault() //Добавление рандомного элемента и событие
        {
            T data = new T();
            Node<T> node = new Node<T>(data);
            // если список пуст
            if (head == null)
            {
                head = node;
                tail = node;
                tail.Next = head;
                CollectionCountChanged?.Invoke(this, new CollectionHandlerEventArgs(data, $"\n\tДобавлен {data} "));
            }
            else
            {
                node.Next = head;
                tail.Next = node;
                tail = node;
                CollectionCountChanged?.Invoke(this, new CollectionHandlerEventArgs(data, $"\n\tДобавлен {data} "));
            }
            count++;
        }

        public override void AddFew(T[] data1)
        {
            foreach (var item in data1)
            {
                Add(item);
            }
            
        }


        public  bool RemoveIndex1(int index) // Удаление по индексу
        {
            if (index < Count && index >= 0)
            {             
                this.RemoveByIndex(index);
                CollectionCountChanged?.Invoke(this.Name, new CollectionHandlerEventArgs(this[index], $"\n\tУдален {this[index]} по индексу {index}"));
                return true;
            }
            else
                return false;
        }
    }

    
}
