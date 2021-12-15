using Library.Domain.Entities;
using System.Data.SqlClient;

namespace Library.Infrastructure.Repositories
{
    /// <summary>
    /// Class provides access to work with books table to authors table in database
    /// </summary>
    public class BookToAuthorRepository : ReflectionRepositoryBase<BookToAuthor>
    {
        /// <summary>
        /// Book to author repository constructor
        /// </summary>
        /// <param name="connectionString">Connection string</param>
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

        protected override Task CreateRelations(BookToAuthor entity)
        {
            return Task.Factory.StartNew(() => { });
        }
    }
}
