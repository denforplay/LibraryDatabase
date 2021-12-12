namespace Library.Domain.Interfaces
{
    /// <summary>
    /// Describes CRUD operations to work with database
    /// </summary>
    /// <typeparam name="T">Type of repository data</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Create in database entity
        /// </summary>
        /// <param name="entity">Entity to add</param>
        /// <returns>Operation of creating entity</returns>
        Task Create(T entity);

        /// <summary>
        /// Read entity by id
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns></returns>
        Task<T> Read(int id);

        /// <summary>
        /// Read all entities in table
        /// </summary>
        /// <returns>Operation of reading a list of data in table</returns>
        Task<IEnumerable<T>> ReadAll();

        /// <summary>
        /// Update entity in table
        /// </summary>
        /// <param name="id">Updated entity id</param>
        /// <param name="entity">Entity from where use data</param>
        /// <returns>Operation of updating entity</returns>
        Task Update(int id, T entity);

        /// <summary>
        /// Delete entity in table
        /// </summary>
        /// <param name="id">Id of entity to delete</param>
        /// <returns>Operation of deleting entity</returns>
        Task Delete(int id);
    }
}
