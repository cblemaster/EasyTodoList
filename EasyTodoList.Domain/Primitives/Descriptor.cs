
namespace EasyTodoList.Domain.Primitives;

public class Descriptor
{
    public ValidString Value { get; init; }

    private Descriptor(ValidString value) => Value = value;

    public static Descriptor ConstructOrThrowArgumentException(string value) =>
        string.IsNullOrWhiteSpace(value) || value.Length > 100
        ? throw new ArgumentException(value)
        : new Descriptor(ValidString.Construct(value));
}
