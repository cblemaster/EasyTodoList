
namespace EasyTodoList.Domain;

internal class Todo
{
    internal string Description { get; init; } = string.Empty;
    internal DateOnly? DueDate { get; init; }
    internal bool IsImportant { get; init; }
    internal bool IsComplete { get; init; }
    internal DateTime CreateDate { get; init; }
    internal DateTime? UpdateDate { get; init; }
    internal Guid Id { get; init; }

    private Todo() { }

    private Todo(string description, DateOnly? dueDate, bool isImportant, bool isComplete, DateTime createDate, DateTime? updateDate, Guid id)
    {
        Description = description;
        DueDate = dueDate;
        IsImportant = isImportant;
        IsComplete = isComplete;
        CreateDate = createDate;
        UpdateDate = updateDate;
        Id = id;
    }

    public Todo Construct(string description, DateOnly? dueDate, bool isImportant, bool isComplete, DateTime createDate, DateTime? updateDate, Guid id) =>
        new(description, dueDate, isImportant, isComplete, createDate, updateDate, id);
}
