using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesStats()
        {
            // Arrange
            var book = new Book("");

            book.AddGrade(95.6);
            book.AddGrade(85.2);
            book.AddGrade(88.3);

            // Act
            var stats = book.GetStatistics();

            // Assert
            Assert.Equal(89.7, stats.Average, 1);
            Assert.Equal(95.6, stats.Max, 1);
            Assert.Equal(85.2, stats.Min, 1);
            
        }
    }
}

