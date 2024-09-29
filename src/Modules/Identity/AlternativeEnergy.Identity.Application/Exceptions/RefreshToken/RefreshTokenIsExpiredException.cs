namespace AlternativeEnergy.Identity.Application.Exceptions.RefreshToken
{
    [Serializable]
    internal sealed class RefreshTokenIsExpiredException : InvalidOperationException
    {
        public RefreshTokenIsExpiredException()
        {
        }

        public RefreshTokenIsExpiredException(string? message) : base(message)
        {
        }

        public RefreshTokenIsExpiredException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
