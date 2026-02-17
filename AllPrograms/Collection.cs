using System;
using System.Collections;
using System.Collections.ObjectModel;

namespace Day45
{
    class Program
    {
        static void Main()
        {
            CollectionClassesDemo();
            Console.ReadLine();
        }

        public static void CollectionClassesDemo()
        {
            Collection<string> list = new Collection<string>();
            list.Add("1");
            list.Add("2");
            list.Add("3");
            list.Add("4");

            foreach (var item in list)
            {
                Console.WriteLine(item);  
            }

            IEnumerable nums = new int[] { 1, 2, 3 };

            foreach (var n in nums)
            {
                Console.WriteLine(n);
            }
        }
    }
}
