using Library.Domain.Configurations;
using Library.Infrastructure.Repositories;

namespace Library.Infrastructure
{
    public class UnitOfWork
    {
        private static object _syncObject;
        private static AbonentRepository _abonentRepository;

        public static AbonentRepository GetAbonentRepository
        {
            get
            {
                if (_abonentRepository is null)
                    lock (_syncObject)
                        _abonentRepository = new AbonentRepository(ConnectionStrings.MSSQLConnectionString);

                return _abonentRepository;
            }
        }
    }
}
