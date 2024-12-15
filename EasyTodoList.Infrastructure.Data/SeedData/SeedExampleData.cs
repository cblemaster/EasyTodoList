
using EasyTodoList.Domain.DataTransfer;
using EasyTodoList.Domain.Entities;

namespace EasyTodoList.Infrastructure.Data.SeedData;

internal class SeedExampleData
{
    internal static IEnumerable<Todo> GenerateExampleTodoEnumerable()
    {
        CreateTodo t1 = new() { Description = "", DueDate = null, IsImportant = false, IsComplete = false };
        CreateTodo t2 = new() { Description = "", DueDate = DateOnly.FromDateTime(DateTime.Today.AddDays(0)), IsImportant = true, IsComplete = false };
        CreateTodo t3 = new() { Description = "", DueDate = null, IsImportant = false, IsComplete = true };
        CreateTodo t4 = new() { Description = "", DueDate = DateOnly.FromDateTime(DateTime.Today.AddDays(3)), IsImportant = true, IsComplete = false };
        CreateTodo t5 = new() { Description = "", DueDate = DateOnly.FromDateTime(DateTime.Today.AddDays(-7)), IsImportant = false, IsComplete = true };
        CreateTodo t6 = new() { Description = "", DueDate = DateOnly.FromDateTime(DateTime.Today.AddDays(10)), IsImportant = false, IsComplete = false };
        CreateTodo t7 = new() { Description = "", DueDate = DateOnly.FromDateTime(DateTime.Today.AddDays(-1)), IsImportant = true, IsComplete = false };
        CreateTodo t8 = new() { Description = "", DueDate = DateOnly.FromDateTime(DateTime.Today.AddDays(0)), IsImportant = false, IsComplete = true };

        return Todo.ConstructEnumerable([t1, t2, t3, t4, t5, t6, t7, t8]);
    }
}
