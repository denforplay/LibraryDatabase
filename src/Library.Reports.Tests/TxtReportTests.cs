using Library.Domain.Configurations;
using Library.Infrastructure.Repositories;
using Library.Reports.Implementations;
using System;
using Xunit;

namespace Library.Reports.Tests
{
    public class TxtReportTests
    {
        [Fact]
        public void TestTxtReport()
        {
            TxtReport txtReport = new TxtReport(new AbonentRepository(ConnectionStrings.MSSQLConnectionString), new AbonentToBookRepository(ConnectionStrings.MSSQLConnectionString));
            txtReport.WriteBookFrequencyReport("txtreport.txt");
        }

        [Fact]
        public void TestWriteAbonentBooksReport()
        {
            TxtReport txtReport = new TxtReport(new AbonentRepository(ConnectionStrings.MSSQLConnectionString), new AbonentToBookRepository(ConnectionStrings.MSSQLConnectionString));
            txtReport.WriteAbonentsBooksReport("txtreport2.txt", DateTime.MinValue, DateTime.MaxValue);
        }
    }
}
