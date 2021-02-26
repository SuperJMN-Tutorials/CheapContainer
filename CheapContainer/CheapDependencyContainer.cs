
using System;
using System.Collections.Generic;

namespace CheapContainer
{
    public class CheapDependencyContainer
    {
        private Dictionary<Type, Type> mappings = new();

        public void Register<TKey, TResult>()
        {
            mappings.Add(typeof(TKey), typeof(TResult));
        }

        public object Resolve<T>()
        {
            var type = mappings[typeof(T)];

            var instance = Activator.CreateInstance(type);
            return instance;
        }
    }
}