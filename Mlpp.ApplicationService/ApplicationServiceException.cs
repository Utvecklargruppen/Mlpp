using System;
using System.Runtime.Serialization;

namespace Mlpp.ApplicationService
{
    [Serializable]
    public class ApplicationServiceException : Exception
    {
        public ApplicationServiceException()
        {
        }

        public ApplicationServiceException(string message) : base(message)
        {
        }

        public ApplicationServiceException(string message, Exception inner) : base(message, inner)
        {
        }

        protected ApplicationServiceException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}