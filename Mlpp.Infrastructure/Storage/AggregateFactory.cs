using System;
using System.Reflection;

namespace Mlpp.Infrastructure.Storage
{
    public class AggregateFactory : IAggregateFactory
    {
        public TAggregate Create<TAggregate, TState>(TState state) where TAggregate : class
        {
            if (state == null)
            {
                return null;
            }

            return (TAggregate)Activator.CreateInstance(
                typeof(TAggregate),
                BindingFlags.Public | BindingFlags.Instance,
                null,
                state,
                null);
        }
    }
}
