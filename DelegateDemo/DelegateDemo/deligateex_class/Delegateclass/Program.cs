using System;

namespace DelegatesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            DelegatesDemoApp app = new DelegatesDemoApp();

            // Call higher-order function demo
            app.HigherOrderFunctionDemo();
        }
    }

    class DelegatesDemoApp
    {
       
        public void HigherOrderFunctionDemo()
        {
            // Passing AreaOfRectangle as a parameter
            var result = CalculateArea(AreaOfRectangle);

            Console.WriteLine($"Area: {result}");

            // Try triangle also (optional)
            var triangleArea = CalculateArea(AreaOfTriangle);
            Console.WriteLine($"Triangle Area: {triangleArea}");
        }

        // ---------------- Higher Order Function ----------------
        int CalculateArea(Func<int, int, int> areaFunction)
        {
            // Calling the passed function
            return areaFunction(5, 10);
        }

        // ---------------- Rectangle Area ----------------
        int AreaOfRectangle(int length, int width)
        {
            return length * width;
        }

        // ---------------- Triangle Area ----------------
        int AreaOfTriangle(int baseLength, int height)
        {
            return (baseLength * height) / 2;
        }
    }
}