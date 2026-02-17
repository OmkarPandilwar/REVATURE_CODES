using System.Dynamic;
using System.Collections.Generic;
using System.Linq;

using System;
namespace Linq
{
    class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string loc { get; set; }
    }
    class Orders
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public double amount { get; set; }
    }

    class program
    {
        static void Main()
        {
            List<Customer> c = new List<Customer>
            {
                new Customer{CustomerId=1,CustomerName="karan",loc="ramtek"},
                new Customer{ CustomerId=2,CustomerName="subodh",loc="chandrapur"},
                new Customer { CustomerId=3,CustomerName="Aniket",loc="bhandara"}
            }; 

            List<Orders> o = new List<Orders>
            {
              new Orders{OrderId=101,CustomerId=1,amount=1000},
              new Orders{OrderId=102,CustomerId=2,amount=1200},
              new Orders {OrderId=103,CustomerId=3,amount=3000}
            };


            //join  Query 

            var CustOrdDetails =
            from c1 in c
            join o1 in o
            on c1.CustomerId equals o1.CustomerId
            select new
            {
                c1.CustomerName,
                o1.OrderId,
                o1.amount
            };

            Console.WriteLine("Customer orders:");
            foreach (var item in CustOrdDetails)
            {
                Console.WriteLine(item.CustomerName + " - " + item.OrderId + " - " + item.amount);
            }
        }




    }












}