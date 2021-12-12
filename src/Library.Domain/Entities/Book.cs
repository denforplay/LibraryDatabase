using Library.Domain.Attributes;
using Library.Domain.Base;
using Library.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    [Table("BookTable")]
    public class Book : EntityBase<int>
    {
        [NotTableField]
        public override int Id { get; set; }

        public string Title { get; set; }
        public int GenreId { get; set; }

        [NotTableField]
        public Enums.BookState State { get; set; }

        [NotTableField]
        public BookGenre Genre { get; set; }

        [NotTableField]
        public IEnumerable<Author> Authors { get; set; }
    }
}
