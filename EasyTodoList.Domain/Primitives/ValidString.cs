
namespace EasyTodoList.Domain.Primitives;

public class ValidString
{
    public string Value { get; init; } = string.Empty;

    private ValidString(string value) => Value = value;

    public static ValidString Construct(string value) => new(value);
}
