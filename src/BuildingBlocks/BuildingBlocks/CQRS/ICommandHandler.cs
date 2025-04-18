using MediatR;

namespace BuildingBlocks.CQRS;

public interface ICommandHandler<in TCommand> 
    : IRequestHandler<TCommand, Unit>
    where TCommand : ICommand<Unit>
{
    // Marker interface for command handlers
}

public interface ICommandHandler<in TCommand, TResponse> 
    : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
    where TResponse : notnull
{
    // Marker interface for command handlers
}