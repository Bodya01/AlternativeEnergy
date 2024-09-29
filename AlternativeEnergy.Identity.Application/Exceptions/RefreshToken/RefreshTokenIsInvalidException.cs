using AlternativeEnergy.Identity.Application.Exceptions.Abstractions;

namespace AlternativeEnergy.Identity.Application.Exceptions.RefreshToken
{
    [Serializable]
    internal class RefreshTokenIsInvalidException : NotFoundException
    {
        public RefreshTokenIsInvalidException()
        {
        }

        public RefreshTokenIsInvalidException(string? message) : base(message)
        {
        }

        public RefreshTokenIsInvalidException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
