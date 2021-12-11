using Library.Domain.Configurations;
using Library.Infrastructure.Repositories;
using System.Linq;
using Xunit;

namespace Library.Infrastructure.Tests.RepositoriesTests
{
    public class BookToGenreRepositoryTests
    {
        private BookToGenreRepository _bookToGenreRepository = new BookToGenreRepository(ConnectionStrings.MSSQLConnectionString);

        [Fact]
        public async void TestReadBookToGenreById()
        {
            var booksToGenres = await _bookToGenreRepository.ReadAll();
            var bookToGenreById = await _bookToGenreRepository.Read(booksToGenres.Last().Id);
            Assert.NotNull(bookToGenreById);
        }

        [Fact]
        public async void TestReadAllBookToGenres()
        {
            var booksToGenre = await _bookToGenreRepository.ReadAll();
            Assert.NotNull(booksToGenre);
        }
    }
}
