using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DanskeBank_Task
{
    public class NumberArray
    {
        public int Id { get; set; }
        public string Array { get; set; }
        public string IsReachable { get; set; }
        public string Path { get; set; }

        public NumberArray()
        {
            
        }

        public NumberArray(int id, string array, string isReachable, string path)
        {
            Id = id;
            Array = array;
            IsReachable = isReachable;
            Path = path;
        }
    }
}