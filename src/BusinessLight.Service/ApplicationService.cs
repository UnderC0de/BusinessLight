namespace BusinessLight.Service
{
    using System;

    using BusinessLight.Data;
    using BusinessLight.Mapping;
    using BusinessLight.Validation;

    public abstract class ApplicationService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;
        private readonly IMapper mapper;
        private readonly IValidationFactory validationFactory;

        protected ApplicationService(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper, IValidationFactory validationFactory)
        {
            if (unitOfWorkFactory == null)
            {
                throw new ArgumentNullException(nameof(unitOfWorkFactory));
            }

            if (mapper == null)
            {
                throw new ArgumentNullException(nameof(mapper));
            }

            if (validationFactory == null)
            {
                throw new ArgumentNullException(nameof(validationFactory));
            }

            this.unitOfWorkFactory = unitOfWorkFactory;
            this.mapper = mapper;
            this.validationFactory = validationFactory;
        }

        protected IUnitOfWork GetUnitOfWork()
        {
            return this.unitOfWorkFactory.GetUnitOfWork();
        }

        protected TDestination Map<TDestination, TSource>(TSource source)
        {
            return this.mapper.Map<TDestination, TSource>(source);
        }

        protected ValidationResult Validate<T>(T instance)
        {
            return this.validationFactory.GetValidatorFor<T>().GetValidationResult(instance);
        }

        protected void ValidateAndThrow<T>(T instance)
        {
            var validationResult = Validate(instance);

            if (validationResult.HasErrors)
            {
                throw new ValidationException(validationResult);
            }
        }
    }
}
