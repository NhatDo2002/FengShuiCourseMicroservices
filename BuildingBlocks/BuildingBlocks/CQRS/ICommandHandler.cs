namespace BuildingBlocks.CQRS
{
    public interface ICommandHandler<in TRequest> : ICommandHandler<TRequest, Unit>
        where TRequest : ICommand
    {
    }

    public interface ICommandHandler<in TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : ICommand<TResponse>
        where TResponse : notnull
    {
    }
}
