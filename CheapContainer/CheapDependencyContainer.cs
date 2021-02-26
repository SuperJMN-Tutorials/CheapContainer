using System;
using System.Collections.Generic;

namespace CheapContainer
{
    public class CheapDependencyContainer
    {
        private readonly Dictionary<Type, Type> mappings = new();

        public void Register<TKey, TResult>()
        {
            mappings.Add(typeof(TKey), typeof(TResult));
        }

        public T Resolve<T>()
        {
            var type = mappings[typeof(T)];
            var instance = Activator.CreateInstance(type);
            return (T) instance;
        }
    }
}