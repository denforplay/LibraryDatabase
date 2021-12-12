using Library.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    /// <summary>
    /// Entity presents state of book
    /// </summary>
    [Table("StatesTable")]
    public class State : EntityBase<int>
    {
        /// <summary>
        /// Book state
        /// </summary>
        public Enums.BookState Value { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is State other)
            {
                return Id == other.Id;
            }

            return false;
        }

        public override int GetHashCode()
        {
            int hash = 1234;
            hash += HashCode.Combine(Id, Value);
            return hash;
        }

        public override string ToString()
        {
            return $"Gender: {Value}";
        }
    }
}
