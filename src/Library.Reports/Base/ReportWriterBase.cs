using Library.Domain.Entities;
using Library.Domain.Interfaces;

namespace Library.Reports.Base
{
    /// <summary>
    /// Represents report writer base
    /// </summary>
    public abstract class ReportWriterBase : IReportWriter
    {
        protected IRepository<Abonent> _abonentRepository;
        protected IRepository<AbonentBook> _abonentBooksRepository;

        /// <summary>
        /// Report writer constructor
        /// </summary>
        /// <param name="abonentRepository">Abonent repository</param>
        /// <param name="abonentToBookRepository">Abonent to book repository</param>
        public ReportWriterBase(IRepository<Abonent> abonentRepository, IRepository<AbonentBook> abonentToBookRepository)
        {
            _abonentRepository = abonentRepository;
            _abonentBooksRepository = abonentToBookRepository;
        }

        public abstract void WriteAbonentsBooksReport(string filepath, DateTime fromTime, DateTime toTime);

        public abstract void WriteBookFrequencyReport(string filepath);
    }
}
