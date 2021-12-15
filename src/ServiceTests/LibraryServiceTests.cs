using Library.Domain.Configurations;
using Library.Domain.Interfaces.Services;
using Library.Infrastructure.Repositories;
using Library.Service;
using Xunit;

namespace ServiceTests
{
    public class LibraryServiceTests
    {
        private ILibraryService _libraryService = new LibraryService();

        [Fact]
        public void TestGetMostFrequenceAuthor()
        {
            var author = _libraryService.GetMostFrequenceAuthor();
            Assert.NotNull(author);
        }

        [Fact]
        public void TestGetMostLikedGenre()
        {
            var genre = _libraryService.GetMostLikedGenre();
            Assert.NotNull(genre);
        }

        [Fact]
        public void TestGetMostReadedAbonent()
        {
            var abonent = _libraryService.GetMostReadedAbonent();
            Assert.NotNull(abonent);
        }

        [Fact]
        public void Test()
        {
            var booksNeededRepair = _libraryService.GetBooksNeedsRepair();
            Assert.NotNull(booksNeededRepair);
        }
    }
}
