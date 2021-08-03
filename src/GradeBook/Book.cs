using System.Collections.Generic;
using System;

namespace GradeBook 
{
    public class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }
        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }
        public Statistic GetGradeStats() {
            var result = new Statistic();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low= double.MaxValue;

            double value = 0;

            foreach (var grade in grades)
            {
                var sum = value += grade;
                result.Low = Math.Min(grade, result.Low);
                result.High = Math.Max(grade, result.High);
                result.Average = (sum / grades.Count);
            }
            return result;
        }
        private string name;
        private List<double> grades;
    }
}