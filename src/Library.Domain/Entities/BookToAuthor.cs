using Library.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    /// <summary>
    /// Entity presents author id for book id
    /// </summary>
    [Table("BookAuthorsTable")]
    public class BookToAuthor : EntityBase<int>
    {
        /// <summary>
        /// Id of book author
        /// </summary>
        public int AuthorId { get; set; }
    }
}
