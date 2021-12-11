using Library.Domain.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Base
{
    public interface IEntityBase<TKey>
    {
        TKey Id { get; set; }
    }

    public abstract class EntityBase<TKey> : IEntityBase<TKey>
    {
        public virtual TKey Id { get; set; }
    }
}
