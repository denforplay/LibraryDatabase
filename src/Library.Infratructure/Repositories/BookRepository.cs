using Library.Domain.Configurations;
using Library.Domain.Entities;
using Library.Domain.Enums;
using System.Data.SqlClient;
using System.Linq;

namespace Library.Infrastructure.Repositories
{
    public class BookRepository : ReflectionRepositoryBase<Book>
    {
        public BookRepository(string connectionString) : base(connectionString)
        {
        }

        protected override Task<Book> CreateFromReader(SqlDataReader dataReader)
        {
            int id = int.Parse(dataReader[nameof(Book.Id)].ToString());
            int genreId = int.Parse(dataReader[nameof(Book.GenreId)].ToString());
            var bookAuthors = new BookToAuthorRepository(ConnectionStrings.MSSQLConnectionString).ReadAll().Result.Where(x => x.Id == id).Select(x => x.AuthorId);
            var task = new Task<Book>(() =>
            {
                return new Book
                {
                    Id = id,
                    GenreId = genreId,
                    Title = dataReader[nameof(Book.Title)].ToString(),
                    Authors = new AuthorsRepository(ConnectionStrings.MSSQLConnectionString).ReadAll().Result.Where(x => bookAuthors.Contains(x.Id)),
                    Genre = Enum.Parse<BookGenre>(new GenreRepository(ConnectionStrings.MSSQLConnectionString).ReadAll().Result.First(x => x.Id == genreId).Name)
                };
            });

            task.Start();
            return task;
        }
    }
}
