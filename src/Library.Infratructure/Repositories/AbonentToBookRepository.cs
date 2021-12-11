using Library.Domain.Entities;
using System.Data.SqlClient;

namespace Library.Infrastructure.Repositories
{
    public class AbonentToBookRepository : ReflectionRepositoryBase<AbonentBook>
    {
        public AbonentToBookRepository(string connectionString) : base(connectionString)
        {
        }

        protected override Task<AbonentBook> CreateFromReader(SqlDataReader dataReader)
        {
            var task = new Task<AbonentBook>(() =>
            {
                return new AbonentBook
                {
                    Id = int.Parse(dataReader[nameof(AbonentBook.Id)].ToString()),
                    BookId = int.Parse(dataReader[nameof(AbonentBook.BookId)].ToString()),
                    TakenDate = DateTime.Parse(dataReader[nameof(AbonentBook.TakenDate)].ToString())
                };
            });

            task.Start();
            return task;
        }
    }
}
