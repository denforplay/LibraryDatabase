using Library.Domain.Configurations;
using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Library.Infrastructure.Repositories;

namespace Library.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private IRepository<Abonent> _abonentRepository;
        private IRepository<Book> _bookRepository;

        public IRepository<Abonent> AbonentRepository => _abonentRepository ??= new AbonentRepository(ConnectionStrings.MSSQLConnectionString);
        public IRepository<Book> BookRepository => _bookRepository ??= new BookRepository(ConnectionStrings.MSSQLConnectionString);
    }
}
