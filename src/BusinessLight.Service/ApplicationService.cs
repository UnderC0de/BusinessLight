using System;
using BusinessLight.Data;
using BusinessLight.Mapping;
using BusinessLight.Validation;

namespace BusinessLight.Service
{
    public abstract class ApplicationService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IMapper _mapper;
        private readonly IValidationFactory _validationFactory;

        protected ApplicationService(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper, IValidationFactory validationFactory)
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

        //protected IMapper GetMapper()
        //{
        //    return _mapper;
        //}

        protected TDestination Map<TDestination, TSource>(TSource source)
        {
            return _mapper.Map<TDestination, TSource>(source);
        }

        protected ValidationResult Validate<T>(T instance)
        {
            return _validationFactory.GetValidatorFor<T>().GetValidationResult(instance);
        }

        protected void ValidateAndThrow<T>(T instance)
        {
            var validationResult = Validate(instance);

            if (validationResult.HasErrors)
            {
                throw new ValidationException(validationResult);
            }
        }

        //protected IValidationFactory GetValidationFactory()
        //{
        //    return _validationFactory;
        //}

        //protected IValidationFactory GetValidationFactory()
        //{
        //    return _validationFactory;
        //}
    }
}
