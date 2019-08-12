using System;
using Xunit;

namespace GradeBook.Tests
{

    public delegate string WriteLogDelegate(string logMessage);    

    public class TypeTests
    {
        int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += IncrementCount;

            var result = log("Hello");
            Assert.Equal(3, count);
        }
        string ReturnMessage(string message)
        {
            count++;
            return message;
        }
        string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }

        [Fact]
        public void StringgsBehaveLikeValue()
        {
            string name = "Angel";
            var upper = MakeUppercase(name);

            Assert.NotEqual("ANGEL", name);
            Assert.Equal("ANGEL", upper);
        }

        private string MakeUppercase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(out x);

            Assert.Equal(42, x);
        }
        private void SetInt(out int z)
        {
            z = 42;
        }
        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetRefSetName(ref book1, "New Name");               // 'out' insted of 'ref' keyword also pass by reference.

            Assert.Equal("New Name", book1.Name);
        }

        private void GetRefSetName(ref Book book, string name)  // 'out' insted of 'ref' keyword also pass by reference.
        {
            book = new Book(name);
        }


        [Fact]
        public void CSharpIsPassByValue()
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
            var book1 = GetBook("Book 1");
            SetName0(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }

        private void SetName0(Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void ParametersByValueTest()
        {
            var book1 = GetBook("Book 1");
            SetName1(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void SetName1(Book book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBooksReturnDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVariablesReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
        }

        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
