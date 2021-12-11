using Library.Infrastructure.Repositories;

namespace Library.Reports.Base
{
    public abstract class ReportWriterBase : IReportWriter
    {
        protected AbonentRepository _abonentRepository;
        protected AbonentToBookRepository _abonentBooksRepository;

        public ReportWriterBase(AbonentRepository abonentRepository, AbonentToBookRepository abonentToBookRepository)
        {
            _abonentRepository = abonentRepository;
            _abonentBooksRepository = abonentToBookRepository;
        }

        public abstract void WriteAbonentsBooksReport(string filepath, DateTime fromTime, DateTime toTime);

        public abstract void WriteBookFrequencyReport(string filepath);
    }
}
