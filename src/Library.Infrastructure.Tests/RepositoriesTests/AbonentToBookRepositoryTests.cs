using Library.Domain.Configurations;
using Library.Infrastructure.Repositories;
using System.Linq;
using Xunit;

namespace Library.Infrastructure.Tests.RepositoriesTests
{
    public class AbonentToBookRepositoryTests
    {
        private AbonentToBookRepository _abonentToBookRepository = new AbonentToBookRepository(ConnectionStrings.MSSQLConnectionString);

        [Fact]
        public async void TestReadAbonentToBookById()
        {
            var abonentsToBooks = await _abonentToBookRepository.ReadAll();
            var abonentToBookById = await _abonentToBookRepository.Read(abonentsToBooks.Last().Id);
            Assert.NotNull(abonentToBookById);
        }

        [Fact]
        public async void TestReadAllAbonentsToBooks()
        {
            var abonentsToBooks = _abonentToBookRepository.ReadAll().Result;
            Assert.NotNull(abonentsToBooks);
        }
    }
}
