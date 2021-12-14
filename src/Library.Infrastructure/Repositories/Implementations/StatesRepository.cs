using Library.Domain.Entities;
using System.Data.SqlClient;

namespace Library.Infrastructure.Repositories
{
    /// <summary>
    /// Class provides access to work with states table in database
    /// </summary>
    public class StatesRepository : ReflectionRepositoryBase<State>
    {
        /// <summary>
        /// States repository constructor
        /// </summary>
        /// <param name="connectionString">Connection to database string</param>
        public StatesRepository(string connectionString) : base(connectionString)
        {
        }

        protected override Task<State> CreateFromReader(SqlDataReader dataReader)
        {
            var task = new Task<State>(() =>
            {
                return new State
                {
                    Id = int.Parse(dataReader[nameof(State.Id)].ToString()),
                    Value = (Domain.Enums.BookState)Enum.Parse(typeof(Domain.Enums.BookState), dataReader[nameof(State.Value)].ToString()),
                };
            });
            task.Start();
            return task;
        }
    }
}