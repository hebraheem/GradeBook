using System.Collections.Generic;
using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("hebraheem book");
            book.AddGrade(89.3);
            var result =book.GetGradeStats();

            Console.WriteLine($"the average grade is {result.Average:N3}");
            Console.WriteLine($"the highest grade is {result.High}");
            Console.WriteLine($"the lowest grade is {result.Low}");

        }
    }

 
}
