using System;
using System.Runtime.Serialization;

namespace Mlpp.Domain
{
    [Serializable]
    public class DomainValidationException : Exception
    {
        public DomainValidationException()
        {
        }

        public DomainValidationException(string message) : base(message)
        {
        }

        public DomainValidationException(string message, Exception inner) : base(message, inner)
        {
        }

        protected DomainValidationException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }   
}
