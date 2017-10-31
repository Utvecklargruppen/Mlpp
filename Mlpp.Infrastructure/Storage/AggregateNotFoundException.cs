using System;

namespace Mlpp.Infrastructure.Storage
{
    public class AggregateNotFoundException : Exception
    {
        public AggregateNotFoundException()
        {
        }

        public AggregateNotFoundException(string message) : base(message)
        {
        }

        public AggregateNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }
    }   
}
