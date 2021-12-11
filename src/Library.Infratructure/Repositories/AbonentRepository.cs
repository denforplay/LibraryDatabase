using Library.Domain.Entities;
using System.Data.SqlClient;

namespace Library.Infrastructure.Repositories
{
    public class AbonentRepository : ReflectionRepositoryBase<Abonent>
    {
        public AbonentRepository(string connectionString) : base(connectionString)
        {
        }

        protected override Task<Abonent> CreateFromReader(SqlDataReader dataReader)
        {
            var task = new Task<Abonent>(() =>
            {
                return new Abonent
                {
                    Id = int.Parse(dataReader[nameof(Abonent.Id)].ToString()),
                    Name = dataReader[nameof(Abonent.Name)].ToString(),
                    Surname = dataReader[nameof(Abonent.Surname)].ToString(),
                    Patronymic = dataReader[nameof(Abonent.Patronymic)].ToString(),
                    GenderId = int.Parse(dataReader[nameof(Abonent.GenderId)].ToString()),
                    BirthDate = DateTime.Parse(dataReader[nameof(Abonent.BirthDate)].ToString())
                };
            });

            task.Start();
            return task; 
        }
    }
}
