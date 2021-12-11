using Library.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    [Table("BookGenresTable")]
    public class BookToGenre : EntityBase<int>
    {
        public int GenreId { get; set; } 
    }
}
