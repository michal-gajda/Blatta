namespace Blatta.Application.Commands;

using Blatta.Application.Common;

public sealed record SetName : ICommand
{
    public required string Name { get; init; }
}
