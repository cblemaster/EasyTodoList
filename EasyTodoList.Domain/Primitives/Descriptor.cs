
namespace EasyTodoList.Domain.Primitives;

public class Descriptor
{
    public string Value { get; init; } = string.Empty;

    private Descriptor(string value) => Value = value;

    public static Descriptor Construct(string value) => new(value);
}
