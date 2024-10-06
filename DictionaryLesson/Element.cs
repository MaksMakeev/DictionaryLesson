using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryLesson
{
    internal class Element
    {
        public int Key { get; set; }
        public string Value { get; set; }
        public Element(int key, string value) 
        {
            Key = key;
            Value = value;
        }
    }
}
