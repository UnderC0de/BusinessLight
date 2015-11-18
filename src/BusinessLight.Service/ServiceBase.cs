using System;
using BusinessLight.Data;

namespace BusinessLight.Service
{
    public abstract class ServiceBase
    {
        private readonly IUnitOfWork _unitOfWork;

        protected ServiceBase(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("unitOfWork");
            }

            _unitOfWork = unitOfWork;
        }

        protected IUnitOfWork GetUnitOfWork()
        {
            return _unitOfWork;
        }
    }
}
