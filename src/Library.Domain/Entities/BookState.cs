using Library.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    [Table("BookStatesTable")]
    public class BookState : EntityBase<int>
    {
        public Enums.BookState Value { get; set; }
    }
}
