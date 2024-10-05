using System.Net;

namespace AlternativeEnergy.DDD.Exceptions
{
    public abstract class ApplicationException : Exception
    {
        public HttpStatusCode Code { get; protected set; }

        protected ApplicationException(HttpStatusCode code, string? message) : base(message)
        {
            Code = code;
        }
    }
}
