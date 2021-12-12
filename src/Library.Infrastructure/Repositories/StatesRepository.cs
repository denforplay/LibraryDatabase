using Library.Domain.Entities;
using System.Data.SqlClient;

namespace Library.Infrastructure.Repositories
{
    public class StatesRepository : ReflectionRepositoryBase<State>
    {
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