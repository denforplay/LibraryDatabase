using Library.Domain.Configurations;
using Library.Infrastructure.Repositories;
using Library.Reports.Implementations;
using System;
using Xunit;

namespace Library.Reports.Tests
{
    public class TxtReportTests
    {
        TxtReport txtReport = new TxtReport(new AbonentRepository(ConnectionStrings.MSSQLConnectionString), new AbonentToBookRepository(ConnectionStrings.MSSQLConnectionString));

        [Fact]
        public void TestTxtReport()
        {
            txtReport.WriteBookFrequencyReport("txtreport.txt");
        }

        [Fact]
        public void TestWriteAbonentBooksReport()
        {
            txtReport.WriteAbonentsBooksReport("txtreport2.txt", DateTime.MinValue, DateTime.MaxValue);
        }
    }
}
