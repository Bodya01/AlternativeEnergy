namespace AlternativeEnergy.Regions.Domain.Exceptions
{
    internal sealed class RegionNameIsEmptyException : Exception
    {
        public RegionNameIsEmptyException(string? message) : base(message)
        {
        }
    }
}
