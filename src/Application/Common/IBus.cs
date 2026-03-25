namespace Blatta.Application.Common;

public interface IBus
{
    Task Send<TCommand>(TCommand command, CancellationToken cancellationToken = default) where TCommand : ICommand;

    Task<TResponse> Send<TCommand, TResponse>(TCommand command, CancellationToken cancellationToken = default) where TCommand : ICommand<TResponse>;

    Task<TResponse> Query<TQuery, TResponse>(TQuery query, CancellationToken cancellationToken = default) where TQuery : IQuery<TResponse>;

    Task Publish<TEvent>(TEvent @event, CancellationToken cancellationToken = default) where TEvent : IEvent;
}
