using System;
using Xunit;
using System.Collections.Generic;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void TwoVariablesHoldSameInstanceButThenGetNewInstancesEach()
        {
            var book1 = new Book("Book 1");
            var book2 = book1;

            Assert.Equal(book1.Name, book2.Name);

            book2 = new Book("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
        }

        [Fact]
        public void SimpleMethodCallCanDeepCopy() {
            var book = new Book("Sample book");
            var copiedBook = DeepCopy<Book>(book);

            copiedBook.Name = "Copied Book";

            Assert.Equal("Copied Book", book.Name);
            Assert.Equal("Copied Book", copiedBook.Name);
        }

        public T DeepCopy<T>(T objectToCopy)
        {
            return objectToCopy;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetName(ref Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void CSharpPassesByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = new Book("Book 1");
            SetName(book1, "New Book Name");

            Assert.Equal("New Book Name", book1.Name);
        }

        private void SetName(Book book1, string name)
        {
            book1.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
        }

        [Fact]
        public void TwoVariablesHoldSameInstance()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 1", book2.Name);
        } 

        private Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}

