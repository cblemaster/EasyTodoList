﻿// <auto-generated />
using System;
using System.Collections.Generic;
using EasyTodoList.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EasyTodoList.Infrastructure.Data.Migrations
{
    [DbContext(typeof(EasyTodoListDbContext))]
    partial class EasyTodoListDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("EasyTodoList.Domain.Entities.Todo", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("TEXT");

                    b.Property<DateOnly?>("DueDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsComplete")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsImportant")
                        .HasColumnType("INTEGER");

                    b.ComplexProperty<Dictionary<string, object>>("Dates", "EasyTodoList.Domain.Entities.Todo.Dates#DateTimeStamps", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<DateTime>("CreateDate")
                                .HasColumnType("TEXT");

                            b1.Property<DateTime?>("UpdateDate")
                                .HasColumnType("TEXT");
                        });

                    b.HasKey("Id");

                    b.ToTable("Todo", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
