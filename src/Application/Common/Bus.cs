namespace Blatta.Application.Common;

using Microsoft.Extensions.DependencyInjection;

internal sealed class Bus(IServiceProvider sp) : IBus
{
    public Task Send<TCommand>(TCommand command, CancellationToken cancellationToken = default) where TCommand : ICommand
    {
        var handler = sp.GetRequiredService<ICommandHandler<TCommand>>();

        return handler.Handle(command, cancellationToken);
    }

    public Task<TResponse> Send<TCommand, TResponse>(TCommand command, CancellationToken cancellationToken = default) where TCommand : ICommand<TResponse>
    {
        var handler = sp.GetRequiredService<ICommandHandler<TCommand, TResponse>>();

        return handler.Handle(command, cancellationToken);
    }

    public Task<TResponse> Query<TQuery, TResponse>(TQuery query, CancellationToken cancellationToken = default) where TQuery : IQuery<TResponse>
    {
        var handler = sp.GetRequiredService<IQueryHandler<TQuery, TResponse>>();

        return handler.Handle(query, cancellationToken);
    }

    public Task Publish<TEvent>(TEvent @event, CancellationToken cancellationToken = default) where TEvent : IEvent
    {
        var handlers = sp.GetServices<IEventHandler<TEvent>>();

        return Task.WhenAll(handlers.Select(handler => handler.Handle(@event, cancellationToken)));
    }
}
