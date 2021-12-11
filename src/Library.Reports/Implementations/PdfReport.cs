using iTextSharp.text;
using iTextSharp.text.pdf;
using Library.Infrastructure.Repositories;
using Library.Reports.Base;

namespace Library.Reports.Implementations
{
    public class PdfReport : ReportWriterBase
    {
        public PdfReport(AbonentRepository abonentRepository, AbonentToBookRepository abonentToBookRepository) : base(abonentRepository, abonentToBookRepository)
        {
        }

        public override void WriteReport(string filepath)
        {
            Document document = new Document();
            PdfWriter.GetInstance(document, new FileStream(filepath, FileMode.Create));

            document.Open();
            var abonents = _abonentRepository.ReadAll().Result;
            var booksGroupings = abonents.Select(x => x.Books).SelectMany(x => x).GroupBy(x => x.Id);

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
    }
}
