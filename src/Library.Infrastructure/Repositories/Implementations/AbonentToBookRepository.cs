using Library.Domain.Configurations;
using Library.Domain.Entities;
using System.Data.SqlClient;

namespace Library.Infrastructure.Repositories
{
    /// <summary>
    /// Class provides access to work with abonents to books table in database
    /// </summary>
    public class AbonentToBookRepository : ReflectionRepositoryBase<AbonentBook>
    {

        /// <summary>
        /// Abonent to book repository constructor
        /// </summary>
        /// <param name="connectionString">Connection to database string</param>
        public AbonentToBookRepository(string connectionString) : base(connectionString)
        {
        }

        protected override Task<AbonentBook> CreateFromReader(SqlDataReader dataReader)
        {
            var task = new Task<AbonentBook>(() =>
            {
                var stateId = int.Parse(dataReader[nameof(AbonentBook.StateId)].ToString());
                return new AbonentBook
                {
                    Id = int.Parse(dataReader[nameof(AbonentBook.Id)].ToString()),
                    BookId = int.Parse(dataReader[nameof(AbonentBook.BookId)].ToString()),
                    StateId = stateId,
                    BookState = new StatesRepository(ConnectionStrings.MSSQLConnectionString).ReadAll().Result.First(x => x.Id == stateId).Value,
                    TakenDate = DateTime.Parse(dataReader[nameof(AbonentBook.TakenDate)].ToString())
                };
            });

            task.Start();
            return task;
        }

        protected override Task CreateRelations(AbonentBook entity)
        {
            return Task.Factory.StartNew(() => { });
        }
    }
}
