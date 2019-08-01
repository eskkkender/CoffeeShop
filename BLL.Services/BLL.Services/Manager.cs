using DAL.Abstraction;

namespace BLL.Services
{
    public class Manager
    {
        protected IUnitOfWork UnitOfWork;

        public Manager(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
