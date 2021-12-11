using Library.Domain.Configurations;
using Library.Infrastructure.Repositories;
using System.Linq;
using Xunit;

namespace Library.Infrastructure.Tests.RepositoriesTests
{
    public class BookToAuthorRepositoryTests
    {
        private BookToAuthorRepository _bookToAuthorRepository = new BookToAuthorRepository(ConnectionStrings.MSSQLConnectionString);

        [Fact]
        public async void TestReadBookToAuthorById()
        {
            var bookToAuthors = await _bookToAuthorRepository.ReadAll();
            var bookToAuthorById = await _bookToAuthorRepository.Read(bookToAuthors.Last().Id);
            Assert.NotNull(bookToAuthorById);
        }

        [Fact]
        public async void TestReadAllBooksToAuthor()
        {
            var booksToAuthor = _bookToAuthorRepository.ReadAll().Result;
            Assert.NotNull(booksToAuthor);
        }
    }
}
