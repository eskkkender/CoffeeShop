using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
