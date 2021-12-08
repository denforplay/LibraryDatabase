using Library.Domain.Base;

namespace Library.Domain.Entities
{
    public class BookGenre : EntityBase<int>
    {
        public string Name { get; set; }
    }
}
