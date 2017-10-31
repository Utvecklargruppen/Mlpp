using System;
using System.Reflection;

namespace Mlpp.Toolkit
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
