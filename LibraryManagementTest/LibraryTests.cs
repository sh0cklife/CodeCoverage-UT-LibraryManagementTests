using LibraryManagementSystem;

namespace LibraryManagementTest
{
    [TestFixture]
    public class LibraryTests
    {
        [Test]
        public void AddBook_ShouldAddNewBookToTheLibrary()
        {
            //arrange
            Library library = new Library();

            var newBook = new Book
            {
                Id = 1,
                Title = "Test Book",
                Author = "Denis",
                IsCheckedOut = true

            };

            //act
            library.AddBook(newBook);

            //assert
            var allBooks = library.GetAllBooks();
            Assert.That(allBooks.Count(), Is.EqualTo(1));

            var singleBook = allBooks.First();
            Assert.That(singleBook.Id, Is.EqualTo(newBook.Id));
            Assert.That(singleBook.Title, Is.EqualTo(newBook.Title));
            Assert.That(singleBook.Author, Is.EqualTo(newBook.Author));
            Assert.IsTrue(singleBook.IsCheckedOut);

        }

        [Test]
        public void CheckOutBook_ShouldReturnFalse_IfBookDoesNotExist()
        {
            //arrange
            Library library = new Library();

            //act
            var result = library.CheckOutBook(999);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void CheckOutBook_ShouldReturnFalse_IfBookIsAlreadyCheckedOut()
        {
            //arrange
            Library library = new Library();
            var newBook = new Book()
            {
                Author = "Denis",
                Title = "Demo Title",
                Id = 5,
                IsCheckedOut = true
            };

            //act
            var result = library.CheckOutBook(newBook.Id);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void CheckOutBook_ShouldReturnTrue_IfBookIsNotCheckedOut()
        {
            //arrange
            Library library = new Library();
            var newBook = new Book()
            {
                Author = "Denis",
                Title = "Demo Title",
                Id = 5,
                IsCheckedOut = false
            };

            library.AddBook(newBook);

            //act
            var result = library.CheckOutBook(newBook.Id);

            //Assert
            Assert.IsTrue(result);
            var allBooks = library.GetAllBooks();
            var singleBook = allBooks.First();
            Assert.IsTrue(singleBook.IsCheckedOut);
        }

        [Test]
        public void CheckOutBook_ShouldReturnFalse_IfBookIsAlreadyCheckedOutInLibraryWithMultipleBooks()
        {
            // Arrange
            Library library = new Library();
            var book1 = new Book { Id = 1, IsCheckedOut = false };
            var book2 = new Book { Id = 2, IsCheckedOut = true };
            library.AddBook(book1);
            library.AddBook(book2);

            // Act
            var result = library.CheckOutBook(book2.Id);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ReturnBook_ShouldReturnFalse_IfBookDoesNotExist()
        {
            //arrange
            Library library = new Library();

            var book1 = new Book { Id = 1, IsCheckedOut = false };
            var book2 = new Book { Id = 2, IsCheckedOut = true };
            library.AddBook(book1);
            library.AddBook(book2);

            //act
            var result = library.ReturnBook(999);

            //Assert
            Assert.IsFalse(result);
            
        }

        [Test]
        public void ReturnBook_ShouldReturnFalse_IfBookIsNotCheckedOut()
        {
            //arrange
            var library = new Library();
            var book1 = new Book { Id = 1, IsCheckedOut = false };
            library.AddBook(book1);

            //act
            var result = library.ReturnBook(1);

            //assert
            Assert.IsFalse(result);

        }

        [Test]
        public void ReturnBook_ShouldReturnTrue_IfBookCanBeCheckedOut()
        {
            //arrange
            var library = new Library();
            var book1 = new Book { Id = 1, IsCheckedOut = true };
            library.AddBook(book1);

            //act
            var result = library.ReturnBook(1);

            //assert
            Assert.IsTrue(result);
            var allBooks = library.GetAllBooks();
            var singleBook = allBooks.First();
            Assert.IsFalse(singleBook.IsCheckedOut);
        }
    }
}
