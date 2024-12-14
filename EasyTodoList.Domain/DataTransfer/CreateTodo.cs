
namespace EasyTodoList.Domain.DataTransfer;

public class CreateTodo
{
    public required string Description { get; init; }
    public required DateOnly? DueDate { get; init; }
    public required bool IsImportant { get; init; }
    public required bool IsComplete { get; init; }
}
