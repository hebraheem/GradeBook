using System.Collections.Generic;
using System;

namespace GradeBook
{
    class Program
    {
        static int count = 1;
        static void GradeBookList()
        {
            Book book = EnterBook();

            var result = book.GetGradeStats();

            Console.WriteLine($"the average grade is {result.Average:N3}");
            Console.WriteLine($"the highest grade is {result.High}");
            Console.WriteLine($"the lowest grade is {result.Low}");
            Console.WriteLine($"the letter grade is {result.Letter}");
        }

        private static Book EnterBook()
        {
            var book = new Book("hebraheem book");
            book.GradeAdded += onGradedAdded;

            while (true)
            {
                Console.WriteLine("Pls Enter a valid grade or q to quit");
                var userInput = Console.ReadLine();

                if (userInput == "q")
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

            return book;
        }

        static void onGradedAdded(object sender, EventArgs e)
        {            
            Console.WriteLine($"{count++} Grade Added");
        }

        static void Main(string[] args)
        {
            GradeBookList();
        }
    }

 
}
