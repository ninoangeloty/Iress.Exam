using System;
using System.Collections.Generic;
using System.Text;

namespace Iress.Infrastrcuture
{
    /// <summary>
    /// Simple IoC container
    /// </summary>
    public static class ServiceCollection
    {
        private static Dictionary<Type, Type> _serviceCollection = new Dictionary<Type, Type>();

        /// <summary>
        /// Map a base type to a derived type and save it in a collection for later use
        /// </summary>
        /// <typeparam name="T">Base type</typeparam>
        /// <typeparam name="U">Derived type</typeparam>
        public static void Add<T, U>() where U : T
        {
            _serviceCollection.Add(typeof(T), typeof(U));
        }

        /// <summary>
        /// Resolve a derived type from a base type
        /// </summary>
        /// <typeparam name="T">Base type</typeparam>
        /// <returns></returns>
        public static T Resolve<T>()
        {
            if (_serviceCollection.TryGetValue(typeof(T), out _))
            {
                var instance = _serviceCollection[typeof(T)];
                return (T)Activator.CreateInstance(instance);
            }

            return default(T);
        }

        /// <summary>
        /// Resolve a derived type from a base type
        /// </summary>
        /// <param name="type">Base type</param>
        /// <returns></returns>
        public static object Resolve(Type type)
        {
            if (_serviceCollection.TryGetValue(type, out _))
            {
                var instance = _serviceCollection[type];
                return Activator.CreateInstance(instance);
            }

            return null;
        }
    }
}
