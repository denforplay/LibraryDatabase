using Library.Domain.Entities;
using Library.Domain.Enums;

namespace Library.Domain.Interfaces.Services
{
    public interface ILibraryService
    {
        Author GetMostFrequenceAuthor();
        Abonent GetMostReadedAbonent();
        BookGenre GetMostLikedGenre();
        IEnumerable<Book> GetBooksNeedsRepair();
    }
}
