namespace DictionaryLesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(0%4);
            
            var MyDictionary = new OtusDictionary();
            MyDictionary.Add(0, "cat");

            MyDictionary[1] = new Element(1, "bird");

            MyDictionary.Add(2, "dog");
            MyDictionary.Add(3, "parrot");
            MyDictionary.Add(4, "carrot");
            Console.WriteLine(MyDictionary.Get(0));
            Console.WriteLine(MyDictionary[1].Value);
            Console.WriteLine(MyDictionary[2].Value);
            Console.WriteLine(MyDictionary.Get(3));
            Console.WriteLine(MyDictionary.Get(4));
           
        }
    }
}
