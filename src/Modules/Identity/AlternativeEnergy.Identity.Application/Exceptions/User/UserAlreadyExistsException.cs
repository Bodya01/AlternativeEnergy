namespace AlternativeEnergy.Identity.Application.Exceptions.User
{
    [Serializable]
    internal sealed class UserAlreadyExistsException : InvalidOperationException
    {
        public UserAlreadyExistsException()
        {
        }

        public UserAlreadyExistsException(string? message) : base(message)
        {
        }

        public UserAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
