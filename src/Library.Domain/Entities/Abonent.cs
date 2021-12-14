using Library.Domain.Attributes;
using Library.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    /// <summary>
    /// Entity desribes abonent of library
    /// </summary>
    [Table("AbonentTable")]
    public class Abonent : EntityBase<int>
    {
        /// <summary>
        /// Abonent name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Abonent surname
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Abonent patronymic
        /// </summary>
        public string Patronymic { get; set; }

        /// <summary>
        /// Abonent gender id
        /// </summary>
        public int GenderId { get; set; }

        /// <summary>
        /// Abonent birthdate
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// List of books which abonent ever took
        /// </summary>
        [NotTableField]
        [Relation(Enums.RelationType.OneToMany, typeof(Book), typeof(AbonentBook), nameof(AbonentBook.BookId))]
        public IEnumerable<Book> Books { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is Abonent otherAbonent)
            {
                return Id == otherAbonent.Id;
            }

            return false;
        }

        public override int GetHashCode()
        {
            int hash = 1234;
            hash += HashCode.Combine(Id, Name, Surname, Patronymic, GenderId, BirthDate);

            return hash;
        }

        public override string ToString()
        {
            return $"Abonent {Id}: {Name} {Surname} {Patronymic} {BirthDate}";
        }
    }
}
