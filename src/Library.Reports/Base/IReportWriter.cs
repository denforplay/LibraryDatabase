namespace Library.Reports.Base
{
    /// <summary>
    /// Describes functionality of report writers
    /// </summary>
    public interface IReportWriter
    {
        /// <summary>
        /// Writes report about how many times books are readed
        /// </summary>
        /// <param name="filepath">File path</param>
        void WriteBookFrequencyReport(string filepath);

        /// <summary>
        /// Writes report about how many books and with what genres users read in current date interval
        /// </summary>
        /// <param name="filepath">File path</param>
        /// <param name="fromTime">Start time interval</param>
        /// <param name="toTime">End time interval</param>
        void WriteAbonentsBooksReport(string filepath, DateTime fromTime, DateTime toTime);
    }
}
