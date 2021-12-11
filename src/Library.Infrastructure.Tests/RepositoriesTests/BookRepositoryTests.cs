using Library.Domain.Configurations;
using Library.Domain.Entities;
using Library.Infrastructure.Repositories;
using System.Linq;
using Xunit;

namespace Library.Infrastructure.Tests.RepositoriesTests
{
    public class BookRepositoryTests
    {
        private BookRepository _bookRepository = new BookRepository(ConnectionStrings.MSSQLConnectionString);

        [Fact]
        public async void TestAddBook()
        {
            var booksBeforeAdding = await _bookRepository.ReadAll();

            Book book = new Book
            {
                Title = "AAA"
            };

            await _bookRepository.Create(book);
            var booksAfterAdding = await _bookRepository.ReadAll();
            Assert.Equal(booksBeforeAdding.Count(), booksAfterAdding.Count() - 1);
            await _bookRepository.Delete(book.Id);
        }


        [Fact]
        public async void TestDeleteBook()
        {
            var abonentsBeforeDeleting = await _bookRepository.ReadAll();
            var deletedBook = abonentsBeforeDeleting.Last();
            await _bookRepository.Delete(deletedBook.Id);
            var abonentsAfterDeleting = await _bookRepository.ReadAll();
            Assert.Equal(abonentsBeforeDeleting.Count(), abonentsAfterDeleting.Count() + 1);
            await _bookRepository.Create(deletedBook);
        }

        [Fact]
        public async void TestReadBookById()
        {
            var books = await _bookRepository.ReadAll();
            var bookById = await _bookRepository.Read(books.Last().Id);
            Assert.NotNull(bookById);
        }

        [Fact]
        public async void TestReadAllBooksById()
        {
            var books = _bookRepository.ReadAll().Result;
            Assert.NotNull(books);
        }

        [Fact]
        public async void TestUpdateBook()
        {
            var bookBeforeUpdating = _bookRepository.ReadAll().Result.Last();

            var book = new Book
            {
                Title = "New book"
            };
            await _bookRepository.Update(bookBeforeUpdating.Id, book);
            Book bookAfterUpdating = (await _bookRepository.ReadAll()).Last();
            Assert.NotEqual(bookBeforeUpdating.Title, bookAfterUpdating.Title);
            await _bookRepository.Update(bookAfterUpdating.Id, bookBeforeUpdating);
        }
    }
}
