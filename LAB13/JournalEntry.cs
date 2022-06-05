using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramLAB_14
{
    public class JournalEntry
    {
        public string CollectionName { get; set; }
        public string TypeOfChanges { get; set; }
        public string ObjectInfo { get; set; }

        public JournalEntry(string collectionName, string typeOfChanges, string objectInfo)
        {
            CollectionName = collectionName;
            TypeOfChanges = typeOfChanges;
            ObjectInfo = objectInfo;
        }

        public override string ToString()
        {
            return $"Измененная коллекция: {CollectionName}" +
                $"\nТип изменения: {TypeOfChanges}" +
                $"\nИнформация об объекте: {ObjectInfo}\n";
        }
    }
}
