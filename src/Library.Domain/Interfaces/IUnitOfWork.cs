using Library.Domain.Entities;

namespace Library.Domain.Interfaces
{
    /// <summary>
    /// Provides functionality to work with multiple repositories
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Abonent repository
        /// </summary>
        IRepository<Abonent> AbonentRepository { get; }

        /// <summary>
        /// Book repository
        /// </summary>
        IRepository<Book> BookRepository { get; }
    }
}
