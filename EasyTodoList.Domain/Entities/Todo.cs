
using EasyTodoList.Domain.ValueObjects;

namespace EasyTodoList.Domain.Entities;

public class Todo : Entity
{
    public Descriptor Description { get; private set; }
    public DateOnly? DueDate { get; private set; }
    public bool IsImportant { get; private set; }
    public bool IsComplete { get; private set; }
    public DateTimeStamps Dates { get; init; }
    public override Identifier Id { get; init; }

    private Todo() { }  // this private ctor is only here for ef core, so I'm ok with the unresolved warning
    private Todo(string description, DateOnly? dueDate, bool isImportant, bool isComplete)
    {
        Description = Descriptor.ConstructOrThrowArgumentException(description);
        DueDate = dueDate;
        IsImportant = isImportant;
        IsComplete = isComplete;
        Dates = new DateTimeStamps(CreateDate: DateTime.Now, UpdateDate: null);
        Id = new Identifier(Value: Guid.CreateVersion7());
    }

    public static Todo Construct(string description, DateOnly? dueDate, bool isImportant, bool isComplete) =>
        new(description, dueDate, isImportant, isComplete);
    internal void SetDescription(string description) => Description = Descriptor.ConstructOrThrowArgumentException(description);
    internal void SetDueDate(DateOnly? dueDate) => DueDate = dueDate;
    internal void SetIsImportant(bool isImportant) => IsImportant = isImportant;
    internal void SetIsComplete(bool isComplete) => IsComplete = isComplete;
}
