using Mlpp.Toolkit;

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

            return Reflector.CreateInstance<TAggregate>(state);
        }
    }
}
