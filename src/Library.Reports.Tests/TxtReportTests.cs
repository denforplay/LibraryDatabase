using Library.Domain.Configurations;
using Library.Infrastructure.Repositories;
using Library.Reports.Implementations;
using Xunit;

namespace Library.Reports.Tests
{
    public class TxtReportTests
    {
        [Fact]
        public void TestTxtReport()
        {
            TxtReport txtReport = new TxtReport(new AbonentRepository(ConnectionStrings.MSSQLConnectionString), new AbonentToBookRepository(ConnectionStrings.MSSQLConnectionString));
            txtReport.WriteReport("txtreport.txt");
        }
    }
}
