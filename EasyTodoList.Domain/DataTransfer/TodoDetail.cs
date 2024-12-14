
using EasyTodoList.Domain.Primitives;

namespace EasyTodoList.Domain.DataTransfer;

public class TodoDetail
{
    public required string Description { get; init; }
    public required DateOnly? DueDate { get; init; }
    public required bool IsImportant { get; init; }
    public required bool IsComplete { get; init; }
    public required DateTime CreateDate { get; init; }
    public required DateTime? UpdateDate { get; init; }
    public required Guid Id { get; init; }
}
