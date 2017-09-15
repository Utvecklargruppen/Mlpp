using System;

namespace Mlpp.ApplicationService
{
    [Serializable]
    public class ApplicationServiceException : System.Exception
    {
        public ApplicationServiceException()
        {
        }

        public ApplicationServiceException(string message) : base(message)
        {
        }

        public ApplicationServiceException(string message, System.Exception inner) : base(message, inner)
        {
        }

        protected ApplicationServiceException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }
    }   
}
