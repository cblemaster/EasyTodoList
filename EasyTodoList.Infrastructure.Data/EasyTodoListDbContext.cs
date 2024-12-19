
using EasyTodoList.Domain.DataTransfer;
using EasyTodoList.Domain.Entities;
using EasyTodoList.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace EasyTodoList.Infrastructure.Data;

public partial class EasyTodoListDbContext : DbContext
{
    public EasyTodoListDbContext() { }

    public EasyTodoListDbContext(DbContextOptions<EasyTodoListDbContext> options) : base(options) { }

    public virtual DbSet<Todo> Todos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlite("Data Source=easytodolist.dat");

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.Entity<Todo>(entity =>
        {
            entity.ToTable("Todo");
            entity.Property(e => e.Description)
                .HasConversion(d => d.Value.Value, d => Descriptor.ConstructOrThrowArgumentException(d))
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.ComplexProperty(e => e.Dates);
            entity.Property(e => e.Id)
                .HasConversion(d => d.Value, d => new Identifier(d));
        });

    public async Task<Todo> CreateTodoAsync(TodoDTO dto)
    {
        Todo entity = Todo.Construct(dto.Description, dto.DueDate, dto.IsImportant, dto.IsComplete);
        Todos.Add(entity);
        await SaveChangesAsync();
        return entity;
    }
    
    public async Task<Todo> GetTodoByIdAsync(Guid id) => await Todos.SingleAsync(t => t.Id.Value == id);
    
    public IEnumerable<Todo> GetTodos() => Todos.AsEnumerable();
    
    public async Task<bool> UpdateTodoAsync(Guid id, TodoDTO dto)
    {
        Todo entity = await GetTodoByIdAsync(id);
        if (entity is not null)
        {
            _ = EntityDTOMapper.MapTodoDTOPropertiesToTodoEntityProperties(entity, dto);

            await SaveChangesAsync();
            return true;
        }
        return false;
    }
    
    public async Task<bool> DeleteTodoAsync(Guid id)
    {
        Todo entity = await GetTodoByIdAsync(id);
        if (entity is not null)
        {
            Todos.Remove(entity);
            await SaveChangesAsync();
            return true;
        }
        return false;
    }
}
