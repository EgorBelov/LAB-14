using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramLAB_14
{
    public class CollectionHandlerEventArgs : EventArgs
    {
        public object ObjectOfChange { get; set; }
        public string Message { get; set; }

        public CollectionHandlerEventArgs(object objectOfChanges, string message)
        {
            ObjectOfChange = objectOfChanges;
            Message = message;
        }
    }
}
