using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Ormconsole;

class Program
{
    static void Main(string[] args)
    {
        using var db = new AppDbContext(); 

        // INSERT
        // var student = new List<Student>
        // {
        // new Student{ Name = "Omkar",Age = 22},
        // new Student {Name="kunal",Age=34},.....................................
        // new Student{Name ="vinod",Age=22},
        //  new Student{Name ="harish",Age=29}

        // };

    //    db.Students.AddRange(student); // for multiple data of student 
      //  db.SaveChanges(); // 

        //Console.WriteLine("Student inserted successfully.");

        //  here we READ the data 
    //  var students = db.Students.ToList();

    //     foreach (var s in students)
    //     {
    //         Console.WriteLine($"{s.Id} - {s.Name} - {s.Age}");
    //     }




    //using var dbb = new AppDbContext();
        





// deleting  student by Id
//var student1 = db.Students.FirstOrDefault(s => s.Id == 1 );


// if (student1 != null)
// {
//     db.Students.Remove(student1);   
//     db.SaveChanges();              
//     Console.WriteLine("  1 Student deleted.");
// }
// else
// {
//     Console.WriteLine("Student not found.");
// }

// Console.WriteLine(" deleting multiple records by where caluse");

//  var stu =db.Students
//             .Where(s=>s.Age==22)
//             .ToList();

//     db.Students.RemoveRange(stu);
//     db.SaveChanges();

//     Console.WriteLine("multiple records deleted as per given condition ");
//     Console.WriteLine("-----------------------------------------------");



// to update the data ---


Console.WriteLine("here we update");

    var update1=db.Students.Where(ss=>ss.Name=="kunal")
    .ToList();

        foreach(var std in update1)
        {
            std.Name="ravi";
           
        }
         db.SaveChanges();
        
    Console.WriteLine("updated succesfully");
 
    Console.WriteLine("for single update :");    

    var upd=db.Students.FirstOrDefault(s=>s.Id==3);

            upd.Name="kavi";                                  
            db.SaveChanges();    



    Console.WriteLine("single row updated succesfully .");


 Console.WriteLine("-------------------");
    Console.WriteLine("data in database "); 
     var students = db.Students.ToList();

        foreach (var s in students)
        {
            Console.WriteLine($"{s.Id} - {s.Name} - {s.Age}");
        }



    }
   




}
