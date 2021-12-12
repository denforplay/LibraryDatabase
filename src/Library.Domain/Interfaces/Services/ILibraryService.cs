using Library.Domain.Entities;
using Library.Domain.Enums;

namespace Library.Domain.Interfaces.Services
{
    /// <summary>
    /// Describes lobrary service functionality
    /// </summary>
    public interface ILibraryService
    {
        /// <summary>
        /// Method to find author whose books is more liked
        /// </summary>
        /// <returns>Returns author whose books is more liked</returns>
        Author GetMostFrequenceAuthor();

        /// <summary>
        /// Method to find abonent who readed books more than any other
        /// </summary>
        /// <returns>Returns abonent, who readed the most books</returns>
        Abonent GetMostReadedAbonent();

        /// <summary>
        /// Method to find genre which is favourite beyond abonents
        /// </summary>
        /// <returns>Returns most liked genre</returns>
        BookGenre GetMostLikedGenre();

        /// <summary>
        /// Method to find books that need to be repaired
        /// </summary>
        /// <returns>List of books which needs to be repaired</returns>
        IEnumerable<Book> GetBooksNeedsRepair();
    }
}
