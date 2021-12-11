using Library.Domain.Configurations;
using Library.Domain.Enums;
using Library.Infrastructure.Repositories;
using System.Linq;
using Xunit;

namespace Library.Infrastructure.Tests.RepositoriesTests
{
    public class BookStateRepositoryTests
    {
        BookStatesRepository _bookStatesRepository = new BookStatesRepository(ConnectionStrings.MSSQLConnectionString);

        [Fact]
        public async void TestReadById()
        {
            var state = await _bookStatesRepository.Read(0);
            Assert.Equal(BookState.NotReturned, state.Value);
        }

        [Fact]
        public async void TestReadAll()
        {
            var states = await _bookStatesRepository.ReadAll();
            Assert.NotNull(states);
        }
    }
}
