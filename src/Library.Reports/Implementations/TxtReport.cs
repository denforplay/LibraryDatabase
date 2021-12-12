using Library.Infrastructure.Repositories;
using Library.Reports.Base;

namespace Library.Reports.Implementations
{
    /// <summary>
    /// Represents txt report
    /// </summary>
    public class TxtReport : ReportWriterBase
    {
        /// <summary>
        /// Pdf report constructor
        /// </summary>
        /// <param name="abonentRepository">Repository to work with abonents</param>
        /// <param name="abonentToBookRepository">Repository to work with data of abonents books</param>
        public TxtReport(AbonentRepository abonentRepository, AbonentToBookRepository abonentToBookRepository) : base(abonentRepository, abonentToBookRepository)
        {
        }

        public override void WriteBookFrequencyReport(string filepath)
        {
            var abonents = _abonentRepository.ReadAll().Result;
            var booksGroupings = abonents.
                Select(x => x.Books).
                SelectMany(x => x).
                GroupBy(x => x.Id);

            using (StreamWriter sw = new StreamWriter(filepath))
            {
                for (int i = 0; i < booksGroupings.Count(); i++)
                {
                    var bookGroup = booksGroupings.ElementAt(i);
                    sw.WriteLine($"Book titled {bookGroup.ElementAt(0).Title} was taken {bookGroup.Count()} times");
                }
            }
        }

        public override void WriteAbonentsBooksReport(string filepath, DateTime fromTime, DateTime toTime)
        {
            var abonentsToBooks = _abonentBooksRepository.ReadAll().Result.
                Where(x => x.TakenDate.CompareTo(fromTime) >= 0 && x.TakenDate.CompareTo(toTime) <= 0);
            var abonents = _abonentRepository.ReadAll().Result;
            var abonentBooksGroupedByGenre = abonents.Select(abonent => new
            {
                Name = abonent.Name,
                Surname = abonent.Surname,
                Patronymic = abonent.Patronymic,
                Books = abonent.Books.Where(x => abonentsToBooks.Where(y => y.Id == abonent.Id).Select(x => x.BookId).Contains(x.Id)).GroupBy(x => x.Genre)
            });
             

            using (StreamWriter sw = new StreamWriter(filepath))
            {
                foreach (var abonent in abonentBooksGroupedByGenre)
                {
                    sw.Write($"{abonent.Name} {abonent.Name} {abonent.Patronymic} read: ");
                    foreach (var genreBooks in abonent.Books)
                    {
                        sw.Write($"{genreBooks.Key}: ");
                        foreach (var book in genreBooks)
                        {
                            sw.Write($"{book.Title}, ");
                        }
                        sw.WriteLine();
                    }
                    sw.WriteLine();
                    sw.WriteLine();
                }
            }
        }
    }
}
