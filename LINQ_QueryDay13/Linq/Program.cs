using System;

using System.Collections.Generic;

namespace Linq
{
    public class Person
    {
        public string FirstName
        {
            get; 
            set;
        }
        public string LastName
        {
            get;
            set;
        }
        public int YearExperence
        {
            get;
            set;
        }
        public DateOnly Birthdate
        {
            get;
            set;

        }



    }

public class ListManager
    {
        public static List<Person> LoadSampleData()
        {
           List<Person> output=new List<Person>();
            output.Add(new Person {FirstName="Omkar",LastName="Pandilwar",Birthdate = new DateOnly(2003,11,06),YearExperence=3});
            output.Add(new Person {FirstName="kunal",LastName="deshmukh",Birthdate=new DateOnly(2003,04,11),YearExperence=4});  
            output.Add(new Person {FirstName="Ravi",LastName="upparwar",Birthdate=new DateOnly(1999,08,11),YearExperence=3});  
            output.Add(new Person {FirstName="Balu",LastName="kumar",Birthdate=new DateOnly(1992,02,13),YearExperence=5});  
            output.Add(new Person {FirstName="Munna",LastName="sakure",Birthdate=new DateOnly(2001,09,22),YearExperence=10});  
            output.Add(new Person {FirstName="Rajiv",LastName="nipane",Birthdate=new DateOnly(1998,03,19),YearExperence=8});  
      return output;
      
        }
    }






    class Program
    {
        static void Main()
        {
            List<Person> people =ListManager.LoadSampleData();


            

          //  people =people.OrderByDescending(x=> x.FirstName).ThenByDescending(x=>x.YearExperence).ToList();
          //  people =people.Where(x=>x.YearExperence>5).ToList();
           // people=people.Where(x=>x.FirstName=="Omkar" || x.YearExperence>4).ToList();
           
           //int yearstotal=people.Sum(x=>x.YearExperence);

                int x= people.Where(x=> x.Birthdate.Month == 3).Sum(x=>x.YearExperence);


            Console.WriteLine(x);
           
           
            // foreach (var person in people)
            // {
            //     Console.WriteLine($"{ person.FirstName},{person.LastName},{person.Birthdate},{person.YearExperence}");

            // }
            Console.ReadLine();  
        }
    }    


}