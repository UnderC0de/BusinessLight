using System;
using BusinessLight.Data;
using BusinessLight.Mapping;

namespace BusinessLight.Service
{
    public abstract class ServiceBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        protected ServiceBase(IUnitOfWork unitOfWork, IMapper mapper)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("unitOfWork");
            }
            if (mapper == null)
            {
                throw new ArgumentNullException("mapper");
            }

            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        protected IUnitOfWork GetUnitOfWork()
        {
            return _unitOfWork;
        }

        protected IMapper GetMapper()
        {
            return _mapper;
        }
    }
}
