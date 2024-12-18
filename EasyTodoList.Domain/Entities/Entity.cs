
using EasyTodoList.Domain.ValueObjects;

namespace EasyTodoList.Domain.Entities;

public abstract class Entity
{
    public abstract Identifier Id { get; init; }
}
