using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Linqpractice
{   
public class Program{
     public static void  Main(string[] args){
            List<Student> stud = new()
            {
                new Student{Id=1,Name="omkar",Age=22},
                new Student{Id=2,Name="kunal",Age=22},
                new Student{Id=3,Name="satyarth",Age=21},
                new Student{Id=4,Name="satish",Age=21},
                new Student{Id=5,Name="somu",Age=27},
                new Student{Id=6,Name="himanshu",Age=21}
            };


            // Update 
            var upd=stud.Where(s=>s.Age>22).ToList();
            foreach(var s in upd)
            {
                Console.WriteLine($"Id:{s.Id},Name:{s.Name},Age:{s.Age}");
            }    
     
                // delete 

        var del=stud.Where(s=>s.Name=="kunal").ToList();
        
        foreach(var i in del)
            {
              stud.Remove(i);
Console.WriteLine($"{i.Name} is removed");
            }


                 Console.WriteLine("---------");
                foreach (var o in stud)
            {
                Console.WriteLine($"Id:{o.Id},Name:{o.Name},Age:{o.Age}");
            }

                Console.WriteLine(" order by"); 
            var orderby=stud.OrderByDescending(s=>s.Age);

            foreach(var i in orderby)
            {
          
                Console.WriteLine($"Id:{i.Id},Name:{i.Name},Age:{i.Age}");
          
            }

            
                // group by 

                var groupby=stud.GroupBy(s=>s.Age)
                .ToList();

                foreach(var g in groupby)
                {
                    Console.WriteLine($"Age: {g.Key}");
                    foreach(var s in g)
                    {
                        Console.WriteLine($"  Id: {s.Id}, Name: {s.Name}");
                    }
                }

                    //sql query with groupby order by 
                    var sql=from s in stud
                    group s by s.Age into g
                    orderby g.Key
                    select new { Age = g.Key, Students = g.ToList() };

                }



    class Student
    {
        public int Id{get;set;}
        public string Name{get;set;}
        public int Age{get;set;}
        }
        
        
           }


}


