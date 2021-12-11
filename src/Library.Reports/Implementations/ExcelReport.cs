using Library.Infrastructure.Repositories;
using Library.Reports.Base;
using ClosedXML.Excel;
using System.Linq;
using System.Text;

namespace Library.Reports.Implementations
{
    public class ExcelReport : ReportWriterBase
    {
        public ExcelReport(AbonentRepository abonentRepository, AbonentToBookRepository abonentToBookRepository) : base(abonentRepository, abonentToBookRepository)
        {
        }

        public override void WriteBookFrequencyReport(string filepath)
        {
            var abonents = _abonentRepository.ReadAll().Result;
            var booksGroupings = abonents.Select(x => x.Books).SelectMany(x => x).GroupBy(x => x.Id);
            using (var wbook = new XLWorkbook())
            {
                var ws = wbook.Worksheets.Add("BooksTakenFrequency");
                for (int i = 0; i < booksGroupings.Count(); i++)
                {
                    var bookGroup = booksGroupings.ElementAt(i);
                    ws.Cell($"A{i + 1}").SetValue(bookGroup.ElementAt(0).Title);
                    ws.Cell($"B{i + 1}").SetValue(bookGroup.Count());
                }

                wbook.SaveAs(filepath);
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
            using (var wbook = new XLWorkbook())
            {
                var ws = wbook.Worksheets.Add("BooksTakenFrequency");
                ws.Cell("A1").SetValue("Abonent fio");
                ws.Cell("B1").SetValue("Genre");
                ws.Cell("C1").SetValue("Books");
                int cellIndex = 2;
                foreach (var abonent in abonentBooksGroupedByGenre)
                {
                    string abonentFIO = $"{abonent.Name} {abonent.Name} {abonent.Patronymic}";
                    ws.Cell($"A{cellIndex}").SetValue(abonentFIO);
                    foreach (var genreBooks in abonent.Books)
                    {
                        ws.Cell($"B{cellIndex}").SetValue($"{genreBooks.Key}");
                        StringBuilder books = new StringBuilder();
                        foreach (var book in genreBooks)
                        {
                            books.Append($"{book.Title},");
                        }
                        ws.Cell($"C{cellIndex++}").SetValue(books.ToString());
                    }
                }

                wbook.SaveAs(filepath);
            }
            
        }
    }
}
