using System;

namespace BusinessLight.Core.Ioc
{
    public interface IIocContainer
    {
        T Resolve<T>();

        T Resolve<T>(Type type);

        T Resolve<T>(object argumentsAsAnonymousType);

        object Resolve(Type type);

        object Resolve(Type type, object argumentsAsAnonymousType);

        void Release(object obj);

        bool IsRegistered(Type type);

        bool IsRegistered<T>();
    }
}
