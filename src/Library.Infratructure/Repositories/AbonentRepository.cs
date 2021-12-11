using Library.Domain.Configurations;
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
            int id = int.Parse(dataReader[nameof(Abonent.Id)].ToString());
            var abonentBooks = new AbonentToBookRepository(ConnectionStrings.MSSQLConnectionString).ReadAll().Result.Where(x => x.Id == id).Select(x => x.BookId);

            var task = new Task<Abonent>(() =>
            {
                return new Abonent
                {
                    Id = id,
                    Name = dataReader[nameof(Abonent.Name)].ToString(),
                    Surname = dataReader[nameof(Abonent.Surname)].ToString(),
                    Patronymic = dataReader[nameof(Abonent.Patronymic)].ToString(),
                    GenderId = int.Parse(dataReader[nameof(Abonent.GenderId)].ToString()),
                    BirthDate = DateTime.Parse(dataReader[nameof(Abonent.BirthDate)].ToString()),
                    Books = new BookRepository(ConnectionStrings.MSSQLConnectionString).ReadAll().Result.Where(x => abonentBooks.Contains(x.Id))
                };
            });

            task.Start();
            return task; 
        }
    }
}
