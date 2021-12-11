namespace Library.Reports.Base
{
    public interface IReportWriter
    {
        void WriteBookFrequencyReport(string filepath);
        void WriteAbonentsBooksReport(string filepath, DateTime fromTime, DateTime toTime);
    }
}
