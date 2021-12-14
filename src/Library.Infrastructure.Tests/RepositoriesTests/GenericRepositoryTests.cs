using Library.Domain.Configurations;
using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Library.Infrastructure.Repositories;
using Xunit;

namespace Library.Infrastructure.Tests.RepositoriesTests
{
    public class GenericRepositoryTests
    {
        private IRepository<Abonent> _abonentRepository = new GenericRepository<Abonent>(ConnectionStrings.MSSQLConnectionString);
        private IRepository<Book> _bookRepository = new GenericRepository<Book>(ConnectionStrings.MSSQLConnectionString);

        [Fact]
        public async void TestReadAllAbonents()
        {
            var abonents = await _abonentRepository.ReadAll();
            Assert.NotNull(abonents);
        }
    }
}
