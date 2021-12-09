using Library.Domain.Base;

namespace Library.Domain.Entities
{
    public class Abonent : EntityBase<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public int GenderId { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
