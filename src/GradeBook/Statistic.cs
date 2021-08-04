
using System;
namespace GradeBook
{
    public class Statistic
    {
        public double High;
        public double Low;
        public double sum;
        public int count;
        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var g when g >= 70.0:
                        return 'A';
                    case var g when g >= 60 && g < 70:
                        return 'B';
                    case var g when g >= 50 && g < 60:
                        return 'C';
                    case var g when g >= 40 && g < 50:
                        return 'D';
                    default:
                        return 'F';
                }
            }
        }

        public double Average
        {
            get
            {
                return sum / count;
            }
        }

        public void Add(double number)
        {
            sum += number;
            count++;
            Low = Math.Min(number, Low);
            High = Math.Max(number, High);
        }
        public Statistic()
        {
            sum = 0.0;
            count = 0;
            High = double.MinValue;
            Low = double.MaxValue;
        }
    }

}
