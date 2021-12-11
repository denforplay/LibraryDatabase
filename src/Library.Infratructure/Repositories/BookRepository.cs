using Library.Domain.Configurations;
using Library.Domain.Entities;
using System.Data.SqlClient;
using System.Linq;

namespace Library.Infrastructure.Repositories
{
    public class BookRepository : ReflectionRepository<Book>
    {
        public BookRepository(string connectionString) : base(connectionString)
        {
        }

        protected override Task<Book> CreateFromReader(SqlDataReader dataReader)
        {
            int id = int.Parse(dataReader[nameof(Book.Id)].ToString());
            var bookAuthors = new BookToAuthorRepository(ConnectionStrings.MSSQLConnectionString).ReadAll().Result.Where(x => x.Id == id).Select(x => x.AuthorId);
            var task = new Task<Book>(() =>
            {
                return new Book
                {
                    Id = id,
                    Title = dataReader[nameof(Book.Title)].ToString(),
                    Authors = new AuthorsRepository(ConnectionStrings.MSSQLConnectionString).ReadAll().Result.Where(x => bookAuthors.Contains(x.Id))
                };
            });

            task.Start();
            return task;
        }
    }
}
