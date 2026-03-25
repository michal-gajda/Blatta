namespace Blatta.Application.EventHandlers;

using Blatta.Application.Common;
using Blatta.Application.Events;
using Microsoft.Extensions.Logging;

public sealed class NameSetHandler(ILogger<NameSetHandler> logger) : IEventHandler<NameSet>
{
    public Task Handle(NameSet @event, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Name has been set to {Name}", @event.Name);

        return Task.CompletedTask;
    }
}
