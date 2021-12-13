using Library.Domain.Entities;

namespace Library.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Abonent> AbonentRepository { get; }
        IRepository<Book> BookRepository { get; }
    }
}
