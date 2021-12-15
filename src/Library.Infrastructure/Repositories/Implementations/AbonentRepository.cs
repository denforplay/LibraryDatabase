using Library.Domain.Configurations;
using Library.Domain.Entities;
using System.Data.SqlClient;

namespace Library.Infrastructure.Repositories
{
    /// <summary>
    /// Class provides access to work with abonents in database
    /// </summary>
    public class AbonentRepository : ReflectionRepositoryBase<Abonent>
    {
        /// <summary>
        /// Abonent repository constructor
        /// </summary>
        /// <param name="connectionString"></param>
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

        protected override Task CreateRelations(Abonent entity)
        {
            var abonentBooksRepository = new AbonentToBookRepository(ConnectionStrings.MSSQLConnectionString);
            return Task.Factory.StartNew(async () =>
            {
                var lastAbonent = (await ReadAll()).Last();
                foreach (var book in entity.Books)
                {
                    AbonentBook abonentBook = new AbonentBook
                    {
                        Id = lastAbonent.Id,
                        BookId = book.Id,
                        TakenDate = DateTime.Now,
                        StateId = 0,
                    };

                    await abonentBooksRepository.Create(abonentBook);
                }
            });
        }
    }
}
