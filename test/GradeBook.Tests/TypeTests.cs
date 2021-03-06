using System;
using Xunit;
using System.Collections.Generic;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void ValuetypesAlsoPassByValue()
        {
            // Given
            var x = GetInt();
            // When
            SetInt(ref x);
            // Then
            Assert.Equal(42, x);
        }

        private void SetInt(ref int x)
        {
            x = 42;
        }

        private void SetInt(int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void ByValueCannotSwapReferences()
        {
            /*
            *   This shows that passing values by value in a method just copies whatever value is inside the outside variable and 
            *   pastes it into a new one. Since there is a new object reference in a new variable, any new changes get applied to
            *   this variable that already has a memory pointer. Since the changes get applied to the value in the inside variable,
            *   the outside variable does not change (the change is not forwarded)
            */
            const string BOOK_1 = "Book 1";
            const string BOOK_2 = "Book 2";
            // Given
            var book1 = new InMemoryBook(BOOK_1);
            var book2 = new InMemoryBook(BOOK_2);
            // When
            SwapReferences(book1, book2);
            // Then
            Assert.Equal(BOOK_1, book1.Name);
            Assert.Equal(BOOK_2, book2.Name);
        }
        [Fact]
        public void ByRefCanSwapReferences()
        {
            /*
            *   This shows that passing values by reference to a method gives it the power to modify the outside variable,
            *   in this case to change where the outside reference is pointing to, because since inside the variable we are 
            *   pointing to the outside variable, any changes will be forwarded to the outside variable.
            */
            const string BOOK_1 = "Book 1";
            const string BOOK_2 = "Book 2";
            // Given
            var book1 = new InMemoryBook(BOOK_1);
            var book2 = new InMemoryBook(BOOK_2);
            // When
            SwapReferences(ref book1, ref book2);
            // Then
            Assert.Equal(BOOK_1, book2.Name);
            Assert.Equal(BOOK_2, book1.Name);
        }

        public void SwapReferences(InMemoryBook book1, InMemoryBook book2)
        {
            InMemoryBook tempBook = book1;
            book1 = book2;
            book2 = tempBook;
        }

        public void SwapReferences(ref InMemoryBook book1, ref InMemoryBook book2)
        {
            InMemoryBook tempBook = book1;
            book1 = book2;
            book2 = tempBook;
        }

        [Fact]
        public void TwoVariablesHoldSameInstanceButThenGetNewInstancesEach()
        {
            var book1 = new InMemoryBook("Book 1");
            var book2 = book1;

            Assert.Equal(book1.Name, book2.Name);

            book2 = new InMemoryBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
        }

        [Fact]
        public void SimpleMethodCallCanDeepCopy()
        {
            var book = new InMemoryBook("Sample book");
            var copiedBook = DeepCopy<InMemoryBook>(book);

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

        private void GetBookSetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CSharpPassesByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = new InMemoryBook("Book 1");
            SetName(book1, "New Book Name");

            Assert.Equal("New Book Name", book1.Name);
        }

        private void SetName(InMemoryBook book1, string name)
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

        private InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}

