using Library.Domain.Base;

namespace Library.Domain.Entities
{
    public class Author : EntityBase<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
