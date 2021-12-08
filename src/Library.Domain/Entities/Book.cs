using Library.Domain.Base;

namespace Library.Domain.Entities
{
    public class Book : EntityBase<int>
    {
        int GenreId { get; set; }
        string Name { get; set; }
    }
}
