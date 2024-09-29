using AlternativeEnergy.Identity.Application.Exceptions.Abstractions;

namespace AlternativeEnergy.Identity.Application.Exceptions.User
{
    [Serializable]
    internal sealed class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException() : base() { }

        public UserNotFoundException(string? message) : base(message) { }

        public UserNotFoundException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
