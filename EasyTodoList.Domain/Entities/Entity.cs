
using EasyTodoList.Domain.Primitives;

namespace EasyTodoList.Domain.Entities;

internal abstract class Entity
{
    internal abstract Identifier Id { get; init; }
}
