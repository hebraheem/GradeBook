using System.Reflection.Metadata;
using System.Collections.Generic;
using System;

namespace GradeBook 
{
    public delegate void AddGradeDelegate(object sender, EventArgs args);
     public interface IBook
     {
        void AddGrade(double grade);
        event AddGradeDelegate GradeAdded;
        Statistic GetGradeStats();
        string name { get; }

    }
    public abstract class  Book
    {
        public abstract void AddGrade(double grade);
    }
    public class InMemoryBook : Book, IBook
    {
        public InMemoryBook(string name)
        {
            grades = new List<double>();
            this.name = name;
        }
        public override void AddGrade(double grade)
        {
            if(grade <= 100 && grade > 0 )
            {
                grades.Add(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
                

            } else {
                throw new ArgumentException($"Invalid {nameof(grade)} value");
            }
        }

        public event AddGradeDelegate GradeAdded;

        public Statistic GetGradeStats()
        {
            var result = new Statistic();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            for (var index = 0; index < grades.Count; index += 1)
            {
                result.Low = Math.Min(grades[index], result.Low);
                result.High = Math.Max(grades[index], result.High);
                result.Average += grades[index];
            }
            result.Average /= grades.Count;

            GetLetterGrade(result);

            return result;
        }

        private static void GetLetterGrade(Statistic result)
        {
            switch (result.Average)
            {
                case var g when g >= 70.0:
                    result.Letter = 'A';
                    break;
                case var g when g >= 60 && g < 70:
                    result.Letter = 'B';
                    break;
                case var g when g >= 50 && g < 60:
                    result.Letter = 'C';
                    break;
                case var g when g >= 40 && g < 50:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;
            }
        }
        public string name
        {
            get; private set;
        }
        private List<double> grades;
    }
}