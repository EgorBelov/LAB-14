using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramLAB_14
{
    public class Journal
    {
        public List<JournalEntry> JournalEntrys { get; set; } = new List<JournalEntry>();

        public void Print() // вывод журнаал
        {          
            for (int i = 0; i < JournalEntrys.Count; i++)
            {
                MyMethods.WriteGreen($"Запись {i + 1}");
                Console.WriteLine($"{JournalEntrys[i]}");
            }
        }

        public void OnCollectionCountChanged(object source, CollectionHandlerEventArgs args)
        {
            if (args.ObjectOfChange != null)
            {

                JournalEntrys.Add(new JournalEntry(source.ToString(), args.Message, args.ObjectOfChange.ToString()));
            }
            else
            {
                JournalEntrys.Add(new JournalEntry(source.ToString(), args.Message, "Пустая ссылка"));
            }

        }

        public void OnCollectionReferenceChanged(object source, CollectionHandlerEventArgs args)
        {
            if (args.ObjectOfChange != null)
            {
                JournalEntrys.Add(new JournalEntry(source.ToString(), args.Message, args.ObjectOfChange.ToString()));
            }
            else
            {
                JournalEntrys.Add(new JournalEntry(source.ToString(), args.Message, "Пустая ссылка"));
            }
        }
    }
}
