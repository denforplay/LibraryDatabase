using Library.Domain.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Base
{
    /// <summary>
    /// Interface describes base entity in table
    /// </summary>
    /// <typeparam name="TKey">Type of table id</typeparam>
    public interface IEntityBase<TKey>
    {
        /// <summary>
        /// Entity id
        /// </summary>
        TKey Id { get; set; }
    }

    /// <summary>
    /// Base class describes table entity with id
    /// </summary>
    /// <typeparam name="TKey">Type of entity id</typeparam>
    public abstract class EntityBase<TKey> : IEntityBase<TKey>
    {
        public virtual TKey Id { get; set; }
    }
}
