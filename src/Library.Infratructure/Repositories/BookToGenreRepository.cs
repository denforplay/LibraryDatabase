using Library.Domain.Entities;
using System.Data.SqlClient;

namespace Library.Infrastructure.Repositories
{
    public class BookToGenreRepository : ReflectionRepositoryBase<BookToGenre>
    {
        public BookToGenreRepository(string connectionString) : base(connectionString)
        {
        }

        protected override Task<BookToGenre> CreateFromReader(SqlDataReader dataReader)
        {
            var task = new Task<BookToGenre>(() =>
            {
                return new BookToGenre
                {
                    Id = int.Parse(dataReader[nameof(BookToGenre.Id)].ToString()),
                    GenreId = int.Parse(dataReader[nameof(BookToGenre.GenreId)].ToString())
                };
            });

            task.Start();
            return task;
        }
    }
}
