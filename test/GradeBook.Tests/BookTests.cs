using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteToLogDelegate(string message);
    public class BookTests
    {
        [Fact]
        public void WriteToLogUsingDelegate()
        {
            // Given
            WriteToLogDelegate log = LogToReturn;
            // When
        
            // Then
            Assert.Equal("Hello", log("Hello"));
        }

        public string LogToReturn(string m)
        {
            return m;
        }

        [Fact]
        public void BookCalculatesStats()
        {
            // Arrange
            var book = new Book("Book 1");

            book.AddGrade(95.6);
            book.AddGrade('B');
            book.AddGrade(88.3);

            // Act
            var stats = book.GetStatistics();

            // Assert
            Assert.Equal(88, stats.Average, 1);
            Assert.Equal(95.6, stats.Max, 1);
            Assert.Equal(80.0, stats.Min, 1);
            Assert.Equal('B', stats.Letter);
            
        }

        [Fact]
        public void GradebookDoesNotAcceptInvalidGrades()
        {
            // Given
            var book = new Book("TestBook");
            var initialGradeCount = book.Grades.Count;
            // When
            Assert.Throws<ArgumentException>(() => book.AddGrade(152));
            Assert.Throws<ArgumentException>(() => book.AddGrade(-98));
            // Then
        }

        [Fact]
        public void GradebookDoesNotAcceptEmptyName()
        {
            // Given
            var book = new Book("Sample Book");
            // When
            
            // Then
            Assert.Throws<ArgumentNullException>(() => book.Name = "");
            Assert.Throws<ArgumentNullException>(() => { var book1 = new Book(""); });

        }
    }
}

