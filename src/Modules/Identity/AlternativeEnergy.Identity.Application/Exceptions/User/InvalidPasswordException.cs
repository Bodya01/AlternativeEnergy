namespace AlternativeEnergy.Identity.Application.Exceptions.User
{
    [Serializable]
    internal sealed class InvalidPasswordException : InvalidOperationException
    {
        public InvalidPasswordException()
        {
        }

        public InvalidPasswordException(string? message) : base(message)
        {
        }

        public InvalidPasswordException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
