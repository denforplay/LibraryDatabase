using Library.Domain.Base;

namespace Library.Domain.Entities
{
    public class BookAuthor : EntityBase<int>
    {
        public int AuthorId { get; set; }
    }
}
