namespace AlternativeEnergy.CQRS
{
    public interface IRequest<out TResult> : IBaseRequest { }
    public interface IRequest : IBaseRequest { }
}
