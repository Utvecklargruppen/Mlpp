using Mlpp.Toolkit;
using System;

namespace Mlpp.Domain
{
    public class DomainValidationException : ValidationException
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
    }   
}
