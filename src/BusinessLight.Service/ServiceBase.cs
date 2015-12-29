using System;
using BusinessLight.Data;
using BusinessLight.Mapping;
using BusinessLight.Validation;

namespace BusinessLight.Service
{
    public abstract class CrudServiceBase
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IMapper _mapper;
        private readonly IValidationFactory _validationFactory;

        protected CrudServiceBase(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper, IValidationFactory validationFactory)
        {
            if (unitOfWorkFactory == null)
            {
                throw new ArgumentNullException("unitOfWorkFactory");
            }

            if (mapper == null)
            {
                throw new ArgumentNullException("mapper");
            }

            if (validationFactory == null)
            {
                throw new ArgumentNullException("validationFactory");
            }

            _unitOfWorkFactory = unitOfWorkFactory;
            _mapper = mapper;
            _validationFactory = validationFactory;
        }

        protected IUnitOfWork GetUnitOfWork()
        {
            return _unitOfWorkFactory.GetUnitOfWork();
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
