namespace AlternativeEnergy.Identity.Application.Exceptions.User
{
    [Serializable]
    internal sealed class UserWasNotCreatedException : InvalidOperationException
    {
        public UserWasNotCreatedException()
        {
        }

        public UserWasNotCreatedException(string? message) : base(message)
        {
        }

        public UserWasNotCreatedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
