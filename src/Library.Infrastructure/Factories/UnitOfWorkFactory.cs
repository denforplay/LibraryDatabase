using Library.Domain.Interfaces;

namespace Library.Infrastructure.Factories
{
    public class UnitOfWorkFactory
    {
        private static IUnitOfWork _unitOfWork;
        private static object _lockObject = new object();

        public static IUnitOfWork GetInstance()
        {
            if (_unitOfWork is null)
                lock(_lockObject)
                {
                    _unitOfWork = new UnitOfWork();
                }

            return _unitOfWork;
        }
    }
}
