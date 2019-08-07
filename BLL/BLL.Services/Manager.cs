using DAL.Abstraction;

namespace BLL.Services
{
    public class Manager
    {
        protected IUnitOfWork _unitOfWork;

        public Manager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
