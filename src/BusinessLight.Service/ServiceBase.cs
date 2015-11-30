using System;
using BusinessLight.Data;
using BusinessLight.Mapping;
using BusinessLight.Validation;

namespace BusinessLight.Service
{
    public abstract class CrudServiceBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidationFactory _validationFactory;

        protected CrudServiceBase(IUnitOfWork unitOfWork, IMapper mapper, IValidationFactory validationFactory)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("unitOfWork");
            }

            if (mapper == null)
            {
                throw new ArgumentNullException("mapper");
            }

            if (validationFactory == null)
            {
                throw new ArgumentNullException("unitOfWork");
            }

            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validationFactory = validationFactory;
        }

        protected IUnitOfWork GetUnitOfWork()
        {
            return _unitOfWork;
        }

        protected IMapper GetMapper()
        {
            return _mapper;
        }

        protected IValidationFactory GetValidationFactory()
        {
            return _validationFactory;
        }
    }
}
