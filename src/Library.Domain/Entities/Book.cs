using Library.Domain.Attributes;
using Library.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    [Table("BookTable")]
    public class Book : EntityBase<int>
    {
        [NotTableField]
        public override int Id { get; set; }

        public string Title { get; set; }

        [NotTableField]
        public IEnumerable<Author> Authors { get; set; }

        [NotTableField]
        public IEnumerable<Genre> BookGenres { get; set; }
    }
}
