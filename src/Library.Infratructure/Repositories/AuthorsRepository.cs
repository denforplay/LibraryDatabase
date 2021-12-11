using Library.Domain.Entities;
using System.Data.SqlClient;

namespace Library.Infrastructure.Repositories
{
    public class AuthorsRepository : ReflectionRepository<Author>
    {
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
    }
}
