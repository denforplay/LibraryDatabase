using Library.Domain.Attributes;
using Library.Domain.Base;
using Library.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    [Table("AbonentsBooksTable")]
    public class AbonentBook : EntityBase<int>
    {
        public int BookId { get; set; }
        public DateTime TakenDate { get; set; }
        public int StateId { get; set; }
        [NotTableField]
        public BookState BookState { get; set; }
    }
}
