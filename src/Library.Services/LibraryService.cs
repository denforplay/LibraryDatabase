using Library.Domain.Entities;
using Library.Domain.Enums;
using Library.Domain.Interfaces;
using Library.Domain.Interfaces.Services;

namespace Library.Service
{
    /// <summary>
    /// Represents library service functionality
    /// </summary>
    public class LibraryService : ILibraryService
    {
        private IRepository<Abonent> _abonentRepository;
        private IRepository<Book> _bookRepository;

        /// <summary>
        /// Library service constructor
        /// </summary>
        /// <param name="abonentRepository">Repository to work with abonents data</param>
        /// <param name="bookRepository">Repository to work with book data</param>
        public LibraryService(IRepository<Abonent> abonentRepository, IRepository<Book> bookRepository)
        {
            _abonentRepository = abonentRepository;
            _bookRepository = bookRepository;
        }

        public IEnumerable<Book> GetBooksNeedsRepair()
        {
            var booksNeededRepair = _bookRepository.ReadAll().Result.Where(x => x.State == BookState.Unsatisfactory);

            return booksNeededRepair;
        }

        public Author GetMostFrequenceAuthor()
        {
            var authorsFrequence = _abonentRepository.ReadAll().Result.
                SelectMany(x => x.Books).
                SelectMany(x => x.Authors).
                GroupBy(x => x.Id).
                OrderByDescending(x => x.Count());
            return authorsFrequence.First().First();
        }

        public BookGenre GetMostLikedGenre()
        {
            var genreFrequence = _abonentRepository.ReadAll().Result.
                SelectMany(x => x.Books).
                GroupBy(x => x.Genre).
                OrderByDescending(x => x.Count());

            return genreFrequence.First().Key;
        }

        public Abonent GetMostReadedAbonent()
        {
            return _abonentRepository.ReadAll().Result.OrderByDescending(x => x.Books.Count()).First();
        }
    }
}
