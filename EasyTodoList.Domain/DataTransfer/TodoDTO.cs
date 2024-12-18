
namespace EasyTodoList.Domain.DataTransfer;

internal class TodoDTO
{
    internal string Description { get; set; } = string.Empty;
    internal DateOnly? DueDate { get; set; }
    internal bool IsImportant { get; set; }
    internal bool IsComplete { get; set; }
    internal DateTime CreateDate { get; set; }
    internal DateTime? UpdateDate { get; set; }
    internal Guid Id { get; set; }
}
