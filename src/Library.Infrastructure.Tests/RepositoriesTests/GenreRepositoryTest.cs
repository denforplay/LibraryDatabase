using Library.Domain.Configurations;
using Library.Infrastructure.Repositories;
using Xunit;
using System.Linq;
using Library.Domain.Entities;

namespace Library.Infrastructure.Tests.RepositoriesTests
{
    public class GenreRepositoryTest
    {
        private GenreRepository _bookGenreRepository = new GenreRepository(ConnectionStrings.MSSQLConnectionString);

        //[Fact]
        //public async void TestAddBookGenre()
        //{
        //    var booksGenreBeforeAdding = await _bookGenreRepository.ReadAll();

        //    Genre genre = new Genre
        //    {
        //        Name = "Detective"
        //    };

        //    await _bookGenreRepository.Create(genre);
        //    var booksAfterAdding = await _bookGenreRepository.ReadAll();
        //    Assert.Equal(booksGenreBeforeAdding.Count(), booksAfterAdding.Count() - 1);
        //    await _bookGenreRepository.Delete(genre.Id);
        //}


        //[Fact]
        //public async void TestDeleteBookGenre()
        //{
        //    var genresBeforeDeleting = await _bookGenreRepository.ReadAll();
        //    var deletedGenre = genresBeforeDeleting.Last();
        //    await _bookGenreRepository.Delete(deletedGenre.Id);
        //    var genresAfterDeleting = await _bookGenreRepository.ReadAll();
        //    Assert.Equal(genresBeforeDeleting.Count(), genresAfterDeleting.Count() + 1);
        //    await _bookGenreRepository.Create(deletedGenre);
        //}

        //[Fact]
        //public async void TestUpdateBook()
        //{
        //    var genreBeforeUpdating = _bookGenreRepository.ReadAll().Result.Last();

        //    var genre = new Genre
        //    {
        //        Name = genreBeforeUpdating + "1"
        //    };
        //    await _bookGenreRepository.Update(genreBeforeUpdating.Id, genre);
        //    Genre genreAfterUpdating = (await _bookGenreRepository.ReadAll()).Last();
        //    Assert.NotEqual(genreBeforeUpdating.Name, genreAfterUpdating.Name);
        //    await _bookGenreRepository.Update(genreAfterUpdating.Id, genreBeforeUpdating);
        //}

        [Fact]
        public async void TestReadBookById()
        {
            var genres = await _bookGenreRepository.ReadAll();
            var genreById = await _bookGenreRepository.Read(genres.Last().Id);
            Assert.NotNull(genreById);
        }

        [Fact]
        public async void TestReadAllBooksById()
        {
            var genre = _bookGenreRepository.ReadAll().Result;
            Assert.NotNull(genre);
        }
    }
}
