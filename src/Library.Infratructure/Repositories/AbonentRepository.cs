using Library.Domain.Entities;
using Library.Domain.Interfaces;
using System.Data.SqlClient;

namespace Library.Infrastructure.Repositories
{
    public class AbonentRepository : IRepository<Abonent>
    {
        private string _connectionString;

        public AbonentRepository(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            _connectionString = connectionString;
        }

        public async Task Create(Abonent entity)
        {
            string sqlExpression = $"INSERT INTO AbonentTable (Name, Surname,Patronymic, GenderId, BirthDate) VALUES (@Name, @Surname, @Patronymic, @GenderId, @BirthDate)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Name", entity.Name));
                    command.Parameters.Add(new SqlParameter("@Surname", entity.Surname));
                    command.Parameters.Add(new SqlParameter("@Patronymic", entity.Patronymic));
                    command.Parameters.Add(new SqlParameter("@GenderId", entity.GenderId));
                    command.Parameters.Add(new SqlParameter("@BirthDate", entity.BirthDate));
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task Delete(int id)
        {
            string sqlExpression = $"DELETE FROM AbonentTable WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Id", id));
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public Task<Abonent> Read(int id)
        {
            return null;
        }

        public Task Update(int id, Abonent entity)
        {
            throw new NotImplementedException();
        }
    }
}
