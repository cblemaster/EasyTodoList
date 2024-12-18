
using EasyTodoList.Domain.Entities;
using EasyTodoList.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace EasyTodoList.Infrastructure.Data;

public partial class EasyTodoListDbContext : DbContext
{
    public EasyTodoListDbContext() { }

    public EasyTodoListDbContext(DbContextOptions<EasyTodoListDbContext> options)
        : base(options) { }

    public virtual DbSet<Todo> Todos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlite("Data Source=easytodolist.dat");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todo>(entity =>
        {
            entity.ToTable("Todo");
            entity.Property(e => e.Description)
                .HasConversion(d => d.Value, d => Descriptor.ConstructOrThrowArgumentException(d.Value))
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.ComplexProperty(e => e.Dates);
            entity.Property(e => e.Id)
                .HasConversion(d => d.Value, d => new Identifier(d));
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
