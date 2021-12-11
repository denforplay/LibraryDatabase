using Library.Domain.Attributes;
using Library.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    [Table("AbonentTable")]
    public class Abonent : EntityBase<int>
    {
        [NotTableField]
        public override int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public int GenderId { get; set; }
        public DateTime BirthDate { get; set; }

        [NotTableField]
        public IEnumerable<Book> Books { get; set; }
    }
}
