using Library.Domain.Configurations;
using Library.Infrastructure.Repositories;
using Xunit;
using System.Linq;

namespace Library.Infrastructure.Tests.RepositoriesTests
{
    public class AuthorsRepositoryTests
    {
        private AuthorsRepository _authorsRepository = new AuthorsRepository(ConnectionStrings.MSSQLConnectionString);

        [Fact]
        public async void TestReadAuthorById()
        {
            var authors = await _authorsRepository.ReadAll();
            var authorById = await _authorsRepository.Read(authors.Last().Id);
            Assert.NotNull(authorById);
        }

        [Fact]
        public async void TestReadAllAuthors()
        {
            var authors = await _authorsRepository.ReadAll();
            Assert.NotNull(authors);
        }
    }
}
