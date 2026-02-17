using System;
namespace ExplicitInterface
{
    // when 2 interface have common method        ---------it is explicit interface implementation 

    //here method cannot be access through the class obj 
    //here we access the method through the interface reference 

    interface Itest1
    {
        void show();
    }

    interface Itest2
    {
        void show();
    
    }

class Demo : Itest1, Itest2
    {
        void Itest1.show()
        {
        Console.WriteLine("from Itest1");
                }
        void Itest2.show()
        {
        Console.WriteLine("from Itest2");
        }




    }


    class Program
    {
        public static void Main(string[] args)
        {
            // we cannot access through the class object ,we only accesss through the interface ref 
            Demo d= new Demo();
         //   d.show();// error
                Itest1 i1=d;
                i1.show();
                // interface ref is i1; 
                Itest2 i2=d;
                i2.show();
                // interface ref is i2 ;



        }
    }



}