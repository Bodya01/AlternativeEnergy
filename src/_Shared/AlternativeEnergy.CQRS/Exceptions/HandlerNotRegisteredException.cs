namespace AlternativeEnergy.CQRS.Exceptions
{
    [Serializable]
    internal sealed class HandlerNotRegisteredException : Exception
    {
        public HandlerNotRegisteredException(string? message) : base(message)
        {
        }
    }
}
