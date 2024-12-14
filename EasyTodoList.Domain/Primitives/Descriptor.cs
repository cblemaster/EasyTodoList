namespace EasyTodoList.Domain.Primitives;

internal class Descriptor
{
    internal string Value { get; init; } = string.Empty;

    private Descriptor(string value) => Value = value;

    public static Descriptor Construct(string value) => new(value);
}
