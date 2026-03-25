namespace Blatta.Application.Common;

public interface IEventHandler<TEvent> where TEvent : IEvent
{
    Task Handle(TEvent @event, CancellationToken cancellationToken = default);
}
