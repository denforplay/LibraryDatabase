using Library.Domain.Configurations;
using Library.Domain.Entities;
using Library.Domain.Enums;
using System.Data.SqlClient;
using System.Linq;

namespace Library.Infrastructure.Repositories
{
    /// <summary>
    /// Class provides access to work with books table in database
    /// </summary>
    public class BookRepository : ReflectionRepositoryBase<Book>
    {
        /// <summary>
        /// Book repository
        /// </summary>
        /// <param name="connectionString">Connection to database string</param>
        public BookRepository(string connectionString) : base(connectionString)
        {
        }

        protected override Task<Book> CreateFromReader(SqlDataReader dataReader)
        {
            int id = int.Parse(dataReader[nameof(Book.Id)].ToString());
            int genreId = int.Parse(dataReader[nameof(Book.GenreId)].ToString());
            var bookAuthors = new BookToAuthorRepository(ConnectionStrings.MSSQLConnectionString).ReadAll().Result.Where(x => x.Id == id).Select(x => x.AuthorId);
            var genres = new GenreRepository(ConnectionStrings.MSSQLConnectionString).ReadAll().Result;
            var genreName = genres.First(x => x.Id == genreId).Name;
            var abonentsBooks = new AbonentToBookRepository(ConnectionStrings.MSSQLConnectionString).ReadAll().Result.Where(x => x.BookId == id);
            BookState state;
            if (abonentsBooks.Count() > 0)
                state = abonentsBooks.OrderByDescending(x => x.TakenDate).First().BookState;
            else
                state = BookState.Excellent;
            var task = new Task<Book>(() =>
            {
                return new Book
                {
                    Id = id,
                    GenreId = genreId,
                    Title = dataReader[nameof(Book.Title)].ToString(),
                    State = state,
                    Authors = new AuthorsRepository(ConnectionStrings.MSSQLConnectionString).ReadAll().Result.Where(x => bookAuthors.Contains(x.Id)),
                    Genre = Enum.Parse<BookGenre>(genreName)
                };
            });

            task.Start();
            return task;
        }

        protected override Task CreateRelations(Book entity)
        {
            var booksAuthorsRepository = new BookToAuthorRepository(ConnectionStrings.MSSQLConnectionString);
            return Task.Factory.StartNew(async () =>
            {
                var lastEntityInDb = (await ReadAll()).Last();
                foreach (var author in entity.Authors)
                {
                    BookToAuthor bookAuthor = new BookToAuthor
                    {
                        Id = lastEntityInDb.Id,
                        AuthorId = author.Id,
                    };

                    await booksAuthorsRepository.Create(bookAuthor);
                }
            });
        }
    }
}
