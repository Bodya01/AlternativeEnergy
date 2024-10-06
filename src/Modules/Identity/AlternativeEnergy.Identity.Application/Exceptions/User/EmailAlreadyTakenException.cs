namespace AlternativeEnergy.Identity.Application.Exceptions.User
{
    [Serializable]
    internal sealed class EmailAlreadyTakenException : InvalidOperationException
    {
        public EmailAlreadyTakenException(string? email) : base($"User with email: {email} already exists")
        {
        }
    }
}
