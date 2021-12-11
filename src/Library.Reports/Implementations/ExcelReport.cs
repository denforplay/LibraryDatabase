using Library.Infrastructure.Repositories;
using Library.Reports.Base;
using ClosedXML.Excel;
using System.Linq;

namespace Library.Reports.Implementations
{
    public class ExcelReport : ReportWriterBase
    {
        public ExcelReport(AbonentRepository abonentRepository, AbonentToBookRepository abonentToBookRepository) : base(abonentRepository, abonentToBookRepository)
        {
        }

        public override void WriteReport(string filepath)
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
    }
}
