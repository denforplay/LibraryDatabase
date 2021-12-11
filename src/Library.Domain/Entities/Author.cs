using Library.Domain.Attributes;
using Library.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    [Table("AuthorTable")]
    public class Author : EntityBase<int>
    {
        [NotTableField]
        public override int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
