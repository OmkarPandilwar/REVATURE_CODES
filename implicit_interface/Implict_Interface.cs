using System;
namespace ImplicitInterfaceExample   
// it is a public method 
// it can access via object 
// used when we dont have any Conflict 
{
    interface Iprint
    {
        void print();

    }


interface Iscan
    {
        void scan();
            
        
        
        }

class Machine : Iprint, Iscan
    {
        public void print()
        {
            Console.WriteLine("printing ");
        }

        public void scan()
        {
            Console.WriteLine("Scanning ");
        }
        

    }


    class Program
    {
        public static void Main(string[] args)
        {
            
            Machine m=new Machine();
            m.print();   // access via object 
            m.scan();  // access via object 

            
        }
    }        




    }

