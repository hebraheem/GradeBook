using System.Collections.Generic;
using System;

namespace GradeBook
{
    class Program
    {
        static int count = 1;
        static void Main(string[] args)
        {
            IBook book = new InMemoryBook("hebraheem book");
            book.GradeAdded += onGradedAdded;

            EnterBook(book);
            var result = book.GetGradeStats();

            Console.WriteLine($"the average grade is {result.Average:N3}");
            Console.WriteLine($"the highest grade is {result.High}");
            Console.WriteLine($"the lowest grade is {result.Low}");
            Console.WriteLine($"the letter grade is {result.Letter}");

        }
        // IBook book = new InMemoryBook("hebraheem book");
        // book.GradeAdded += onGradedAdded
        // static int count = 1;
        // static void GradeBookList()
        // {
        //     InMemoryBook book = EnterBook(IBook book);

            // var result = book.GetGradeStats();

            // Console.WriteLine($"the average grade is {result.Average:N3}");
            // Console.WriteLine($"the highest grade is {result.High}");
            // Console.WriteLine($"the lowest grade is {result.Low}");
            // Console.WriteLine($"the letter grade is {result.Letter}");
        // }

        private static IBook EnterBook(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Pls Enter a valid grade or q to compute grade");
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
    }

 
}
