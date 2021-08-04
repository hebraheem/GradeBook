using System;
using GradeBook;
using Xunit;

namespace Gradebook.test
{
    public class BookTest
    {
        [Fact]
        public void InMemoryBookText()
        {
            //arrange
            var Testbook = new InMemoryBook("");
            Testbook.AddGrade(69);
            Testbook.AddGrade(44);
            Testbook.AddGrade(89);

            //act
            var result = Testbook.GetGradeStats();

            //assert
            Assert.Equal(89, result.High, 1);
            Assert.Equal(44, result.Low, 1);
            Assert.Equal(67, result.Average, 0);
            Assert.Equal('B', result.Letter);
        }

        [Fact]
        public void InDiskBookText()
        {
            //arrange
            var diskBook = new InDiskBook("");
            diskBook.AddGrade(69);
            diskBook.AddGrade(44);
            diskBook.AddGrade(89);

            //act
            var result = diskBook.GetGradeStats();

            //assert
            Assert.Equal(89, result.High, 1);
            Assert.Equal(44, result.Low, 1);
            Assert.Equal(67, result.Average, 0);
            Assert.Equal('B', result.Letter);
        }
    }
}
