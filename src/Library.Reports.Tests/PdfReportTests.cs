using Library.Domain.Configurations;
using Library.Infrastructure.Repositories;
using Library.Reports.Implementations;
using Xunit;

namespace Library.Reports.Tests
{
    public class PdfReportTests
    {
        [Fact]
        public void TestPdfReport()
        {
            PdfReport pdfReport = new PdfReport(new AbonentRepository(ConnectionStrings.MSSQLConnectionString), new AbonentToBookRepository(ConnectionStrings.MSSQLConnectionString));
            pdfReport.WriteReport("pdfreport.pdf");
        }
    }
}
