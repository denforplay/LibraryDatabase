using Library.Domain.Attributes;
using Library.Domain.Base;
using Library.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    /// <summary>
    /// Entity describes abonent taken book
    /// </summary>
    [Table("AbonentsBooksTable")]
    public class AbonentBook : EntityBase<int>
    {
        /// <summary>
        /// Id of book owned by abonent
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// Taken date
        /// </summary>
        public DateTime TakenDate { get; set; }

        /// <summary>
        /// Id of book state
        /// </summary>
        public int StateId { get; set; }

        /// <summary>
        /// Book state
        /// </summary>
        [NotTableField]
        public BookState BookState { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is AbonentBook other)
            {
                return Id == other.Id && BookId == other.BookId && TakenDate.CompareTo(other.TakenDate) == 0;
            }

            return false;
        }

        public override int GetHashCode()
        {
            int hash = 1234;
            hash += HashCode.Combine(Id, BookId, BookState, TakenDate);

            return hash;
        }

        public override string ToString()
        {
            return $"Abonent with id {Id} take book with id {BookId} in {TakenDate}. Book state now: {BookState}";
        }
    }
}
