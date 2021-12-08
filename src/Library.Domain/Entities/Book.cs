using Library.Domain.Base;

namespace Library.Domain.Entities
{
    public class Book : EntityBase<int>
    {
        string Title { get; set; }
    }
}
