using System;
using System.Collections.Generic;
using System.Linq;

namespace CheapContainer
{
    public class CheapDependencyContainer
    {
        private readonly Dictionary<Type, Type> mappings = new();

        public void Register<TKey, TResult>()
        {
            mappings.Add(typeof(TKey), typeof(TResult));
        }

        public object Resolve(Type type)
        {
            var toConstruct = mappings[type];

            var constructor = toConstruct
                .GetConstructors()
                .FirstOrDefault();

            var dependencyTypes = constructor.GetParameters().Select(x => x.ParameterType);
            var injectedInstances = dependencyTypes
                .Select(Resolve);

            if (injectedInstances.Any())
            {
                return Activator.CreateInstance(toConstruct, injectedInstances.ToArray());
            }

            return Activator.CreateInstance(toConstruct);
        }

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }
    }
}