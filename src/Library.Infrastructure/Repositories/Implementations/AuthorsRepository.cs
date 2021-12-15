using Library.Domain.Entities;
using System.Data.SqlClient;

namespace Library.Infrastructure.Repositories
{
    /// <summary>
    /// Class provides access to work with authors table in database
    /// </summary>
    public class AuthorsRepository : ReflectionRepositoryBase<Author>
    {

        /// <summary>
        /// Authors repository construcor
        /// </summary>
        /// <param name="connectionString">Connection to database string</param>
        public AuthorsRepository(string connectionString) : base(connectionString)
        {
        }
        protected override Task<Author> CreateFromReader(SqlDataReader dataReader)
        {
            var task = new Task<Author>(() =>
            {
                return new Author
                {
                    Id = int.Parse(dataReader[nameof(Abonent.Id)].ToString()),
                    Name = dataReader[nameof(Author.Name)].ToString(),
                    Surname = dataReader[nameof(Author.Surname)].ToString(),
                };
            });

            task.Start();
            return task;
        }

        protected override Task CreateRelations(Author entity)
        {
            return Task.Factory.StartNew(() => { });
        }
    }
}
