using Library.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    [Table("StatesTable")]
    public class State : EntityBase<int>
    {
        public Enums.BookState Value { get; set; }
    }
}
