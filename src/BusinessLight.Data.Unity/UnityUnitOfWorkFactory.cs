namespace BusinessLight.Data.Unity
{
    using System;

    using Microsoft.Practices.Unity;

    public class UnityUnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IUnityContainer unityContainer;

        public UnityUnitOfWorkFactory(IUnityContainer unityContainer)
        {
            if (unityContainer == null)
            {
                throw new ArgumentNullException(nameof(unityContainer));
            }

            this.unityContainer = unityContainer;
        }

        public IUnitOfWork GetUnitOfWork()
        {
            return this.unityContainer.Resolve<IUnitOfWork>();
        }
    }
}
