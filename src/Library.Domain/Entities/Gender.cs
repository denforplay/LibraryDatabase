using Library.Domain.Attributes;
using Library.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    /// <summary>
    /// Entity presents gender
    /// </summary>
    [Table("GenderType")]
    public class Gender : EntityBase<int>
    {
        [NotTableField]
        public override int Id { get; set; }

        /// <summary>
        /// Gender name
        /// </summary>
        string Name { get; set; }


        public override bool Equals(object? obj)
        {
            if (obj is Gender other)
            {
                return Id == other.Id;
            }

            return false;
        }

        public override int GetHashCode()
        {
            int hash = 1234;
            hash += HashCode.Combine(Id, Name);
            return hash;
        }

        public override string ToString()
        {
            return $"Gender: {Name}";
        }
    }
}
