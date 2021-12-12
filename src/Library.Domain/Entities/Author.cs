using Library.Domain.Attributes;
using Library.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    /// <summary>
    /// Entity describes author
    /// </summary>
    [Table("AuthorTable")]
    public class Author : EntityBase<int>
    {
        [NotTableField]
        public override int Id { get; set; }
        
        /// <summary>
        /// Author name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Author surname
        /// </summary>
        public string Surname { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is Author other)
            {
                return Id == other.Id;
            }

            return false;
        }

        public override int GetHashCode()
        {
            int hash = 1234;
            hash += HashCode.Combine(Id, Name, Surname);

            return hash;
        }

        public override string ToString()
        {
            return $"Author with id {Id}: {Name} {Surname}";
        }
    }
}
