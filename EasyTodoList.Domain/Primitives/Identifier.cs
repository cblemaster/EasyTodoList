
using System.Diagnostics.CodeAnalysis;

namespace EasyTodoList.Domain.Primitives;

internal class Identifier
{
    internal required Guid Value { get; init; }

    [SetsRequiredMembers]
    private Identifier(Guid value) => Value = value;

    public static Identifier Construct() => new(Guid.CreateVersion7());
}
