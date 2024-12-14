namespace EasyTodoList.Domain.Primitives;

internal class Identifier
{
    internal Guid Value { get; init; }

    private Identifier(Guid value) => Value = value;

    public static Identifier Construct() => new(Guid.CreateVersion7());
}
