
using EasyTodoList.Domain.Entities;
using EasyTodoList.Domain.Primitives;
using EasyTodoList.Infrastructure.Data.SeedData;
using Microsoft.EntityFrameworkCore;

namespace EasyTodoList.Infrastructure.Data;

public partial class EasyTodoListDbContext : DbContext
{
    public EasyTodoListDbContext() { }

    public EasyTodoListDbContext(DbContextOptions<EasyTodoListDbContext> options)
        : base(options) { }

    public virtual DbSet<Todo> Todos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder
            .UseSqlite("Data Source=easytodolist.dat")
            .UseSeeding((context, _) =>
            {
                context.Set<Todo>().AddRange(SeedExampleData.GenerateExampleTodoEnumerable());
                context.SaveChanges();

            })
            .UseAsyncSeeding(async (context, _, ct) =>
            {
                context.Set<Todo>().AddRange(SeedExampleData.GenerateExampleTodoEnumerable());
                await context.SaveChangesAsync(ct);
            });     // TODO: Why doesn't the seeding work? Do I need to call .EnsureCreate() ?

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todo>(entity =>
        {
            entity.ToTable("Todo");
            entity.Property(e => e.Description)
                .HasConversion(d => d.Value, d => Descriptor.Construct(d))
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Id)
                .HasConversion(d => d.Value, d => Identifier.Construct());
            entity.ComplexProperty(e => e.Dates);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
