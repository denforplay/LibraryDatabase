using Library.Domain.Base;

namespace Library.Domain.Entities
{
    public class Gender : EntityBase<int>
    {
        string Name { get; set; }
    }
}
