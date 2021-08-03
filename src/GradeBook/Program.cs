using System.Collections.Generic;
using System;

namespace GradeBook
{
    class Program
    {
        static void GradeBookList()
        {
           var book = new Book("hebraheem book");            

            while (true)
            {
                Console.WriteLine("Pls Enter a valid grade or q to quit");
                var userInput =Console.ReadLine();

                if(userInput == "q")
                {
                    break;
                }
                else
                {
                    try
                    {
                       var userGrade = double.Parse(userInput);
                        book.AddGrade(userGrade);  
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                   
                }
            }
            
            var result =book.GetGradeStats();

            Console.WriteLine($"the average grade is {result.Average:N3}");
            Console.WriteLine($"the highest grade is {result.High}");
            Console.WriteLine($"the lowest grade is {result.Low}");
            Console.WriteLine($"the letter grade is {result.Letter}");
        }

        static void Main(string[] args)
        {
            GradeBookList();
        }
    }

 
}
