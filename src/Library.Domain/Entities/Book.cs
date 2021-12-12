using Library.Domain.Attributes;
using Library.Domain.Base;
using Library.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    /// <summary>
    /// Entity describes book
    /// </summary>
    [Table("BookTable")]
    public class Book : EntityBase<int>
    {
        [NotTableField]
        public override int Id { get; set; }

        /// <summary>
        /// Book title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Id of book genre
        /// </summary>
        public int GenreId { get; set; }

        /// <summary>
        /// Book state
        /// </summary>
        [NotTableField]
        public BookState State { get; set; }

        /// <summary>
        /// Book genre
        /// </summary>
        [NotTableField]
        public BookGenre Genre { get; set; }

        /// <summary>
        /// List of book authors
        /// </summary>
        [NotTableField]
        public IEnumerable<Author> Authors { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is Book other)
            {
                return Id == other.Id;
            }

            return false;
        }

        public override int GetHashCode()
        {
            int hash = 1234;
            hash += HashCode.Combine(Id, Title, GenreId);
            return hash;
        }

        public override string ToString()
        {
            return $"Book with id {Id}: {Title}";
        }
    }
}
