using System;
using System.Collections.Generic;
using System.Linq;

namespace CheapContainer
{
    public class CheapDependencyContainer
    {
        private readonly Dictionary<Type, Type> mappings = new();

        public void Register<TKey, TResult>() where TResult : TKey
        {
            mappings.Add(typeof(TKey), typeof(TResult));
        }

        public object Resolve(Type type)
        {
            var typeToBuild = mappings[type];
            var toInject = GetInjectedInstances(typeToBuild);
            return Activator.CreateInstance(typeToBuild, toInject.ToArray());
        }

        private IEnumerable<object> GetInjectedInstances(Type toConstruct)
        {
            var constructor = toConstruct
                .GetConstructors()
                .FirstOrDefault();

            var dependencyTypes = constructor.GetParameters().Select(x => x.ParameterType);
            var injectedInstances = dependencyTypes
                .Select(Resolve);
            return injectedInstances;
        }

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }
    }
}