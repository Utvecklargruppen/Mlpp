using System;
using System.Reflection;

namespace Mlpp.Infrastructure.Utility
{
    public static class Reflector
    {
        public static T CreateInstance<T>(params object[] args)
        {
            var result = (T)Activator.CreateInstance(
                typeof(T),
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance,
                null,
                args,
                null);

            return result;
        }
    }
}
