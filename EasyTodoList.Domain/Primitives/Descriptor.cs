
using System.Diagnostics.CodeAnalysis;

namespace EasyTodoList.Domain.Primitives;

internal class Descriptor
{
    internal required string Value { get; init; } = string.Empty;

    [SetsRequiredMembers]
    private Descriptor(string value) => Value = value;

    public static Descriptor Construct(string value) => new(value);
}
