using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Base
{
    public interface IEntityBase<TKey>
    {
        TKey Id { get; set; }
    }

    public abstract class EntityBase<TKey> : IEntityBase<TKey>
    {
        [Key]
        public TKey Id { get; set; }
    }
}
