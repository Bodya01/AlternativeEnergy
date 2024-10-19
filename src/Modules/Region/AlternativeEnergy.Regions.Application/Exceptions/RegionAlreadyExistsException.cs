using System.Net;
using ApplicationException = AlternativeEnergy.DDD.Exceptions.ApplicationException;

namespace AlternativeEnergy.Regions.Application.Exceptions
{
    [Serializable]
    internal sealed class RegionAlreadyExistsException : ApplicationException
    {
        public RegionAlreadyExistsException(HttpStatusCode code, string? message) : base(code, message) { }
    }
}
