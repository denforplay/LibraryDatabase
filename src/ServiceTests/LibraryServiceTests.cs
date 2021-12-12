using Library.Domain.Configurations;
using Library.Domain.Interfaces.Services;
using Library.Infrastructure.Repositories;
using Library.Service;
using Xunit;

namespace ServiceTests
{
    public class LibraryServiceTests
    {
        private ILibraryService _libraryService = new LibraryService(new AbonentRepository(ConnectionStrings.MSSQLConnectionString), new BookRepository(ConnectionStrings.MSSQLConnectionString));

        [Fact]
        public void TestGetMostFrequenceAuthor()
        {
            var author = _libraryService.GetMostFrequenceAuthor();
        }

        [Fact]
        public void TestGetMostLikedGenre()
        {
            var genre = _libraryService.GetMostLikedGenre();
        }

        [Fact]
        public void TestGetMostReadedAbonent()
        {
            var abonent = _libraryService.GetMostReadedAbonent();
        }

        [Fact]
        public void Test()
        {
            var booksNeededRepair = _libraryService.GetBooksNeedsRepair();
        }
    }
}
