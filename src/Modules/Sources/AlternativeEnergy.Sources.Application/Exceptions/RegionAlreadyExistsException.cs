using AlternativeEnergy.DDD.Exceptions;
using System.Net;
using ApplicationException = AlternativeEnergy.DDD.Exceptions.ApplicationException;

namespace AlternativeEnergy.Sources.Application.Exceptions
{
    internal class RegionAlreadyExistsException : ApplicationException
    {
        public RegionAlreadyExistsException(HttpStatusCode code, string? message) : base(code, message)
        {
        }
    }
}
