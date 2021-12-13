using Library.Domain.Entities;
using Library.Domain.Enums;
using Library.Domain.Interfaces;
using Library.Domain.Interfaces.Services;
using Library.Infrastructure.Factories;

namespace Library.Service
{
    /// <summary>
    /// Represents library service functionality
    /// </summary>
    public class LibraryService : ILibraryService
    {
        public IEnumerable<Book> GetBooksNeedsRepair()
        {
            var booksNeededRepair = UnitOfWorkFactory.GetInstance().BookRepository.ReadAll().Result.Where(x => x.State == BookState.Unsatisfactory);

            return booksNeededRepair;
        }

        public Author GetMostFrequenceAuthor()
        {
            var authorsFrequence = UnitOfWorkFactory.GetInstance().AbonentRepository.ReadAll().Result.
                SelectMany(x => x.Books).
                SelectMany(x => x.Authors).
                GroupBy(x => x.Id).
                OrderByDescending(x => x.Count());
            return authorsFrequence.First().First();
        }

        public BookGenre GetMostLikedGenre()
        {
            var genreFrequence = UnitOfWorkFactory.GetInstance().AbonentRepository.ReadAll().Result.
                SelectMany(x => x.Books).
                GroupBy(x => x.Genre).
                OrderByDescending(x => x.Count());

            return genreFrequence.First().Key;
        }

        public Abonent GetMostReadedAbonent()
        {
            return UnitOfWorkFactory.GetInstance().AbonentRepository.ReadAll().Result.OrderByDescending(x => x.Books.Count()).First();
        }
    }
}
