using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var book = new Book("");

            book.AddGrade(95.6);
            book.AddGrade(85.2);
            book.AddGrade(88.3);

            // Act
            var stats = book.GetStatistics();

            // Assert
            Assert.Equal(stats.Average, 89.7, 1);
            Assert.Equal(stats.Max, 95.6, 1);
            Assert.Equal(stats.Min, 85.2, 1);
            
        }
    }
}

