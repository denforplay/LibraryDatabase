using iTextSharp.text;
using iTextSharp.text.pdf;
using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Library.Infrastructure.Repositories;
using Library.Reports.Base;

namespace Library.Reports.Implementations
{
    /// <summary>
    /// Represents pdf report
    /// </summary>
    public class PdfReport : ReportWriterBase
    {
        /// <summary>
        /// Pdf report constructor
        /// </summary>
        /// <param name="abonentRepository">Repository to work with abonents</param>
        /// <param name="abonentToBookRepository">Repository to work with data of abonents books</param>
        public PdfReport(IRepository<Abonent> abonentRepository, IRepository<AbonentBook> abonentToBookRepository) : base(abonentRepository, abonentToBookRepository)
        {
        }

        public override void WriteBookFrequencyReport(string filepath)
        {
            var abonents = _abonentRepository.ReadAll().Result;
            var booksGroupings = abonents.Select(x => x.Books).SelectMany(x => x).GroupBy(x => x.Id);

            Document document = new Document();
            PdfWriter.GetInstance(document, new FileStream(filepath, FileMode.Create));
            document.Open();
            PdfPTable table = new PdfPTable(2);
            PdfPCell cell1 = new PdfPCell(new Phrase("Book title"));
            PdfPCell cell2 = new PdfPCell(new Phrase("Count of taken"));
            table.AddCell(cell1);
            table.AddCell(cell2);

            for (int i = 0; i < booksGroupings.Count(); i++)
            {
                var bookGroup = booksGroupings.ElementAt(i);
                table.AddCell(new PdfPCell(new Phrase(bookGroup.ElementAt(0).Title)));
                table.AddCell(new PdfPCell(new Phrase(bookGroup.Count().ToString())));
            }

            document.Add(table);

            document.Close();
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

            Document document = new Document();
            PdfWriter.GetInstance(document, new FileStream(filepath, FileMode.Create));
            document.Open();
            PdfPTable table = new PdfPTable(3);
            table.AddCell(new PdfPCell(new Phrase("Abonent FIO")));
            table.AddCell(new PdfPCell(new Phrase("Genre")));
            table.AddCell(new PdfPCell(new Phrase("Books")));

            foreach (var abonent in abonentBooksGroupedByGenre)
            {
                string abonentFIO = $"{abonent.Name} {abonent.Name} {abonent.Patronymic}";
                table.AddCell(new PdfPCell(new Phrase(abonentFIO)));
                var genreCell = new PdfPCell();
                var booksCell = new PdfPCell(new Phrase(""));
                foreach (var genreBooks in abonent.Books)
                {
                    genreCell.Phrase = new Phrase(genreCell.Phrase + $"{genreBooks.Key}\n");
                    foreach (var book in genreBooks)
                    {
                        booksCell.Phrase = new Phrase(booksCell.Phrase.Content + $"{book.Title},");
                    }
                }
                table.AddCell(genreCell);
                table.AddCell(booksCell);
            }

            document.Add(table);

            document.Close();
        }
    }
}
