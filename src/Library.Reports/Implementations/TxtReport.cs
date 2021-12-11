using Library.Infrastructure.Repositories;
using Library.Reports.Base;

namespace Library.Reports.Implementations
{
    public class TxtReport : ReportWriterBase
    {
        public TxtReport(AbonentRepository abonentRepository, AbonentToBookRepository abonentToBookRepository) : base(abonentRepository, abonentToBookRepository)
        {
        }

        public override void WriteReport(string filepath)
        {
            var abonents = _abonentRepository.ReadAll().Result;
            var booksGroupings = abonents.Select(x => x.Books).SelectMany(x => x).GroupBy(x => x.Id);

            using (StreamWriter sw = new StreamWriter(filepath))
            {
                for (int i = 0; i < booksGroupings.Count(); i++)
                {
                    var bookGroup = booksGroupings.ElementAt(i);
                    sw.WriteLine($"Book titled {bookGroup.ElementAt(0).Title} was taken {bookGroup.Count()} times");
                }
            }
        }
    }
}
