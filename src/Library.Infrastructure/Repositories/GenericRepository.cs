using Library.Domain.Attributes;
using Library.Domain.Base;
using Library.Domain.Configurations;
using Library.Domain.Enums;
using System.Collections;
using System.Data.SqlClient;
using System.Reflection;

namespace Library.Infrastructure.Repositories
{
    /// <summary>
    /// Provides functionality to work with any type of data
    /// </summary>
    /// <typeparam name="T">Type of table entity</typeparam>
    public class GenericRepository<T> : ReflectionRepositoryBase<T> where T : EntityBase<int>
    {
        /// <summary>
        /// Generic repository constructor
        /// </summary>
        /// <param name="connectionString">Connection to database string</param>
        public GenericRepository(string connectionString) : base(connectionString)
        {
        }

        protected override async Task<T> CreateFromReader(SqlDataReader dataReader)
        {
            return await Task.Factory.StartNew(() =>
            {
                T instance = Activator.CreateInstance<T>();
                IEnumerable<T> result;
                foreach (var property in _properties)
                {
                    property.SetValue(instance, dataReader[property.Name]);
                }

                var specialProperties = typeof(T).GetProperties().Where(x => x.GetCustomAttribute<RelationAttribute>() is not null);
                foreach (var specialProp in specialProperties)
                {
                    var relationAttribute = specialProp.GetCustomAttribute<RelationAttribute>();
                    var entityRepository = Activator.CreateInstance(typeof(GenericRepository<>).MakeGenericType(relationAttribute.RepositoryEntityType), ConnectionStrings.MSSQLConnectionString);
                    var entityRepositoryRelations = Activator.CreateInstance(typeof(GenericRepository<>).MakeGenericType(relationAttribute.RepositoryRelationEntityType), ConnectionStrings.MSSQLConnectionString);
                    var method = entityRepository.GetType().GetMethod("ReadAll");
                    var method2 = entityRepositoryRelations.GetType().GetMethod("ReadAll");
                    var data = ((IEnumerable<object>)CallGetByReflection(method, entityRepository).Result);
                    var relationsData = ((IEnumerable)CallGetByReflection(method2, entityRepositoryRelations).Result).Cast<object>().
                    Where(x => (int)x.GetType().GetProperty("Id").GetValue(x) == instance.Id).Select(x => (int)x.GetType().GetProperty(relationAttribute.ForeignKeyName).GetValue(x));
                    switch (relationAttribute.RelationType)
                    {
                        case RelationType.OneToMany:
                            {
                                IEnumerable<object> addedData = Activator.CreateInstance(data.GetType(), null) as IEnumerable<object>;
                                foreach (var dataUnit in data)
                                {
                                    if (relationsData.Contains((int)dataUnit.GetType().GetProperty("Id").GetValue(dataUnit)))
                                    {
                                        addedData = addedData.Append(dataUnit);
                                    }
                                }

                                specialProp.SetValue(instance, data);
                            }
                            break;
                    }
                    break;
                }

                return instance;
            });
        }

        private async Task<object> CallGetByReflection(MethodInfo method, object obj)
        {
            return await InvokeAsync(method, obj, null);
        }

        private async Task<object> InvokeAsync(MethodInfo method, object obj, params object[] parameters)
        {
            dynamic awaitable = method.Invoke(obj, parameters);
            await awaitable;
            return awaitable.GetAwaiter().GetResult();
        }
    }
}
