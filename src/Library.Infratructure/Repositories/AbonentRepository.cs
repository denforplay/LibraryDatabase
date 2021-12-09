using Library.Domain.Entities;
using System.Data.SqlClient;

namespace Library.Infrastructure.Repositories
{
    public class AbonentRepository : ReflectionRepository<Abonent>
    {
        public AbonentRepository(string connectionString, string tableName) : base(connectionString, tableName)
        {
        }

        protected override Task<Abonent> CreateFromReader(SqlDataReader dataReader)
        {
            var task = new Task<Abonent>(() =>
            {
                return new Abonent
                {
                    Id = int.Parse(dataReader["Id"].ToString()),
                    Name = dataReader["Name"].ToString(),
                    Surname = dataReader["Surname"].ToString(),
                    Patronymic = dataReader["Patronymic"].ToString(),
                    GenderId = int.Parse(dataReader["GenderId"].ToString()),
                    BirthDate = DateTime.Parse(dataReader["BirthDate"].ToString())
                };
            });
            task.Start();
            return task; 
        }
    }
}
