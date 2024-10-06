using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DictionaryLesson
{
    internal class OtusDictionary
    {
        private Element[] Elements { get; set; }
        private int Size { get; set; }

        public Element this[int i]
        {
            get { return Elements[i]; }
            set {
                if (Elements[i] is not null || i > Size)
                {
                    throw new ArgumentException("Dictionary has already had an element with that key");
                }
                else
                {
                    Elements[i] = value;
                }
            }
        }
        public OtusDictionary()
        {
            Size = 2;
            Elements = new Element[Size];
        }

        public void Add(int key, string value)
        {
            if (!UniqueKeyValidation(key))
            {
                throw new ArgumentException("Dictionary has already had an element with that key");
            }

            if (value == null || value == "")
            {
                throw new ArgumentNullException("Element's value couldn't be empty");
            }

            var elementPosition = GetElementPosition(key);

            if (elementPosition < Size && Elements[elementPosition] is null)
            {
                Elements[elementPosition] = new Element(key, value);
            }
            else
            {
                //Console.WriteLine("The size is not enough");
                PushWithResize(key, value);
            }
        }

        public string Get(int key)
        {
            foreach (Element element in Elements)
            {
                if (element is not null && element.Key == key)
                {
                    return element.Value;
                }
            }
            return "Couldn't find required element";
        }

        private void PushWithResize(int key, string value)
        {
            Size *= 2;
            var TemptArray = new Element[Size];

            foreach (Element element in Elements)
            {
                if (element is not null)
                {
                    TemptArray[GetElementPosition(element.Key)] = element;
                }
            }

            Elements = TemptArray;

            Elements[GetElementPosition(key)] = new Element(key, value);
        }

        private int GetElementPosition(int key)
        {
            var position = key % Size;
            return position;
        }

        private bool UniqueKeyValidation(int key)
        {
            foreach (Element element in Elements)
            {
                if (element is not null && element.Key == key)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
