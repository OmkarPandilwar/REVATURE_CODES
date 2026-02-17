using System;

namespace DelegateDemo
{
    class Program
    {
        
        delegate void MathOperation(int a, int b);  //  Declare delegate

      
        static void Main(string[] args)
        {
         
            MathOperation operation = Subtract;

           
            operation(5, 3);

          
            operation = Add;
            operation(5, 3);
        }

        static void Add(int a, int b)
        {
            Console.WriteLine($"The sum of {a} and {b} is: {a + b}");
        }

        static void Subtract(int a, int b)
        {
            Console.WriteLine($"The difference between {a} and {b} is: {a - b}");
        }
    }
}
