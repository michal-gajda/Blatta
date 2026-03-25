namespace Blatta.Application.CommandHandlers;

using Blatta.Application.Commands;
using Blatta.Application.Common;
using Blatta.Application.Events;
using Microsoft.Extensions.Logging;

public sealed class SetNameHandler(IBus bus, ILogger<SetNameHandler> logger) : ICommandHandler<SetName>
{
    public async Task Handle(SetName command, CancellationToken cancellationToken)
    {
        logger.LogInformation("Setting name to {Name}", command.Name);

        var @event = new NameSet
        {
            Name = command.Name,
        };

        await bus.Publish(@event, cancellationToken);
    }
}
