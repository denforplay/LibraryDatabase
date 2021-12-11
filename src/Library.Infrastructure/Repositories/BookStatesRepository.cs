using Library.Domain.Entities;
using System.Data.SqlClient;

namespace Library.Infrastructure.Repositories
{
    public class BookStatesRepository : ReflectionRepositoryBase<BookState>
    {
        public BookStatesRepository(string connectionString) : base(connectionString)
        {
        }

        protected override Task<BookState> CreateFromReader(SqlDataReader dataReader)
        {
            var task = new Task<BookState>(() =>
            {
                return new BookState
                {
                    Id = int.Parse(dataReader[nameof(BookState.Id)].ToString()),
                    Value = (Domain.Enums.BookState)Enum.Parse(typeof(Domain.Enums.BookState), dataReader[nameof(BookState.Value)].ToString()),
                };
            });
            task.Start();
            return task;
        }
    }
}