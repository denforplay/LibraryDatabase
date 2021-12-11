using Library.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    [Table("BookAuthorsTable")]
    public class BookToAuthor : EntityBase<int>
    {
        public int AuthorId { get; set; }
    }
}
