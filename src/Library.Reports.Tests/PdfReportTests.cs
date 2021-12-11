using Library.Domain.Configurations;
using Library.Infrastructure.Repositories;
using Library.Reports.Implementations;
using System;
using Xunit;

namespace Library.Reports.Tests
{
    public class PdfReportTests
    {
        private PdfReport _pdfReport = new PdfReport(new AbonentRepository(ConnectionStrings.MSSQLConnectionString), new AbonentToBookRepository(ConnectionStrings.MSSQLConnectionString));

        [Fact]
        public void TestPdfReport()
        {
            _pdfReport.WriteBookFrequencyReport("pdfreport.pdf");
        }

        [Fact]
        public void TestPdfAbonentBooksReport()
        {
            _pdfReport.WriteAbonentsBooksReport("pdfreport2.pdf", DateTime.MinValue, DateTime.MaxValue);
        }
    }
}
