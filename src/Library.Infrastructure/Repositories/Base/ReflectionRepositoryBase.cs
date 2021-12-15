using Library.Domain.Attributes;
using Library.Domain.Base;
using Library.Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace Library.Infrastructure.Repositories
{
    /// <summary>
    /// Repository realize crud operations using reflection
    /// </summary>
    /// <typeparam name="T">Type of entity in repository</typeparam>
    public abstract class ReflectionRepositoryBase<T> : IRepository<T> where T : EntityBase<int>
    {
        private string _connectionString;
        private string _tableName;
        protected List<PropertyInfo> _properties;

        /// <summary>
        /// Reflection repository constructor
        /// </summary>
        /// <param name="connectionString">Connection string</param>
        public ReflectionRepositoryBase(string connectionString)
        {

            _connectionString = connectionString;
            _properties = typeof(T).GetProperties().ToList();
            _properties.RemoveAll(x => x.GetCustomAttribute<NotTableFieldAttribute>() is not null);
            _tableName = typeof(T).GetCustomAttribute<TableAttribute>().Name;
        }

        public async Task Create(T entity)
        {
            var propertyNames = _properties.Select(x => x.Name);
            string sqlExpression = string.Format(SqlExpressions.CreateItemExpression, _tableName, string.Join(", ", propertyNames), string.Join(",@", propertyNames).Trim(',').Insert(0, "@"));
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    foreach (var property in _properties)
                        command.Parameters.Add(new SqlParameter($"@{property.Name}", property.GetValue(entity)));

                    await command.ExecuteNonQueryAsync();
                    await CreateRelations(entity);
                }
            }
        }

        protected abstract Task CreateRelations(T entity);

        public async Task Delete(int id)
        {
            string sqlExpression = string.Format(SqlExpressions.DeleteItemExpression, _tableName, "id");

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

        public async Task<T> Read(int id)
        {
            string sqlExpression = string.Format(SqlExpressions.SelectExpression, string.Join(", ", _properties.Select(x => x.Name)).Insert(0, "Id, "), _tableName, "Where Id = @Id");
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    SqlParameter commandId = new SqlParameter("@Id", id);
                    command.Parameters.Add(commandId);
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        var ss = 
                            reader.GetSchemaTable();
                        while(reader.Read())
                        {
                            return await CreateFromReader(reader);
                        }
                    }
                }
            }

            throw new Exception("Some troubles with read in reflection repository");
        }

        /// <summary>
        /// Method creates entity from sql data reader
        /// </summary>
        /// <param name="dataReader">SQL data reader</param>
        /// <returns> Operation of creating new entity</returns>
        protected abstract Task<T> CreateFromReader(SqlDataReader dataReader);

        public async Task<IEnumerable<T>> ReadAll()
        {
            string selectedParameters = string.Join(", ", _properties.Select(x => x.Name)).Insert(0, "Id, ");
            string sqlExpression = string.Format(SqlExpressions.SelectExpression, selectedParameters, _tableName, "");
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var task = new Task<IEnumerable<T>>(() =>
                        {
                            var readedData = new List<T>();
                            while (reader.Read())
                            {
                                readedData.Add(CreateFromReader(reader).Result);
                            }

                            return readedData;
                        });

                        task.Start();
                        return await task;
                    }
                }
            }

            throw new Exception("Some troubles with read in reflection repository");
        }

        public async Task Update(int id, T entity)
        {
            StringBuilder settedParameters = new StringBuilder();
            foreach (var property in _properties)
            {
                settedParameters.Append($"{property.Name}=@{property.Name}, ");
            }

            settedParameters.Remove(settedParameters.Length - 2, 1);
            string sqlExpression = string.Format(SqlExpressions.UpdateItemExpression, _tableName, settedParameters, "WHERE Id = @Id");
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    foreach (var property in _properties)
                        command.Parameters.Add(new SqlParameter($"@{property.Name}", property.GetValue(entity)));

                    command.Parameters.Add(new SqlParameter("@Id", id));

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
