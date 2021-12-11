using Library.Domain.Entities;
using System.Data.SqlClient;

namespace Library.Infrastructure.Repositories
{
    public class BookToAuthorRepository : ReflectionRepositoryBase<BookToAuthor>
    {
        public BookToAuthorRepository(string connectionString) : base(connectionString)
        {
        }

        protected override Task<BookToAuthor> CreateFromReader(SqlDataReader dataReader)
        {
            var task = new Task<BookToAuthor>(() =>
            {
                return new BookToAuthor
                {
                    Id = int.Parse(dataReader[nameof(BookToAuthor.Id)].ToString()),
                    AuthorId = int.Parse(dataReader[nameof(BookToAuthor.AuthorId)].ToString()),
                };
            });

            task.Start();
            return task;
        }
    }
}
