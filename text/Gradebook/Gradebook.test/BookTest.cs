using System;
using GradeBook;
using Xunit;

namespace Gradebook.test
{
    public class BookTest
    {
        [Fact]
        public void Test1()
        {
            //arrange
            var Testbook = new Book("");
            Testbook.AddGrade(69);
            Testbook.AddGrade(44);
            Testbook.AddGrade(89);

            //act
            var result  = Testbook.GetGradeStats();

            //assert
            Assert.Equal(89, result.High, 1);
            Assert.Equal(44, result.Low, 1);
            Assert.Equal(67, result.Average, 0);
        }
    }
}
