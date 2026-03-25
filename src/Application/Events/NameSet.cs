namespace Blatta.Application.Events;

using Blatta.Application.Common;

public sealed record NameSet : IEvent
{
    public required string Name { get; init; }
}
