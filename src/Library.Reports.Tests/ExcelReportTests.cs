using Library.Domain.Configurations;
using Library.Infrastructure.Repositories;
using Library.Reports.Implementations;
using System;
using Xunit;

namespace Library.Reports.Tests
{
    public class ExcelReportTests
    {
        private ExcelReport _excelReport = new ExcelReport(new AbonentRepository(ConnectionStrings.MSSQLConnectionString), new AbonentToBookRepository(ConnectionStrings.MSSQLConnectionString));

        [Fact]
        public void TestWriteBookFrequencyReport()
        {
            _excelReport.WriteBookFrequencyReport("excelreport.xlsx");
        }

        [Fact]
        public void TestWriteAbonentBooks()
        {
            _excelReport.WriteAbonentsBooksReport("excelreport2.xlsx", DateTime.MinValue, DateTime.MaxValue);
        }
    }
}
