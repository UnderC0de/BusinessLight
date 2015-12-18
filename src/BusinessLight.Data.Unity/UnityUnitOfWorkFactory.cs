using System;
using Microsoft.Practices.Unity;

namespace BusinessLight.Data.Unity
{
    public class UnityUnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IUnityContainer _unityContainer;

        public UnityUnitOfWorkFactory(IUnityContainer unityContainer)
        {
            if (unityContainer == null)
            {
                throw new ArgumentNullException("unityContainer");
            }

            _unityContainer = unityContainer;
        }

        public IUnitOfWork GetUnitOfWork()
        {
            return _unityContainer.Resolve<IUnitOfWork>();
        }
    }
}
