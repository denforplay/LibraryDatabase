using Library.Domain.Configurations;
using Library.Infrastructure.Repositories;
using Library.Reports.Implementations;
using Xunit;

namespace Library.Reports.Tests
{
    public class ExcelReportTests
    {
        [Fact]
        public void Test()
        {
            ExcelReport excelReport = new ExcelReport(new AbonentRepository(ConnectionStrings.MSSQLConnectionString), new AbonentToBookRepository(ConnectionStrings.MSSQLConnectionString));
            excelReport.WriteReport("test.xlsx");
        }
    }
}
