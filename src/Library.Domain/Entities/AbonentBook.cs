using Library.Domain.Base;

namespace Library.Domain.Entities
{
    public class AbonentBook : EntityBase<int>
    {
        public int BookId { get; set; }
    }
}
