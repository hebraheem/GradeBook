using System.Collections.Generic;
using System;
using System.IO;
using System.Net;

namespace GradeBook
{
    public class InDiskBook : Book, IBook
    {
        public InDiskBook(string name)
        {
            grades = new List<double>();
            this.name = name;
        }

        public string name
        {
            get;
        }

        public event AddGradeDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade > 0)
            {
                using (var writer = File.AppendText($"{name}.txt"))
                {
                    writer.WriteLine(grade);
                    if (GradeAdded != null)
                    {
                        GradeAdded(this, new EventArgs());
                    }
                }
            }
            else
            {
                throw new FormatException($"Invalid {nameof(grade)} value");
            }

        }

        public Statistic GetGradeStats()
        {
            var result = new Statistic();

            using(var reader = File.OpenText($"{name}.txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }
            
            return result;
        }
        private List<double> grades;
    }
}