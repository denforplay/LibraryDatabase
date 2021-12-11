using Library.Domain.Base;
using Library.Domain.Entities;
using System.Data.SqlClient;

namespace Library.Infrastructure.Repositories
{
    public class GenreRepository : ReflectionRepository<Genre>
    {
        public GenreRepository(string connectionString) : base(connectionString)
        {
        }

        protected override Task<Genre> CreateFromReader(SqlDataReader dataReader)
        {
            var task = new Task<Genre>(() =>
            {
                return new Genre
                {
                    Id = int.Parse(dataReader[nameof(Genre.Id)].ToString()),
                    Name = dataReader[nameof(Genre.Name)].ToString()
                };
            });

            task.Start();
            return task;
        }
    }
}
