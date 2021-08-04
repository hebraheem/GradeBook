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

            for (var index = 0; index < grades.Count; index += 1)
            {
                result.Add(grades[index]);
            }

            return result;
        }
        public string name
        {
            get; private set;
        }
        private List<double> grades;
    }
}