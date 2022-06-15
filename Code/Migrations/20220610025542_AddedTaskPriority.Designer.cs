﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WPF_Project.Data;

#nullable disable

namespace WPF_Project.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220610025542_AddedTaskPriority")]
    partial class AddedTaskPriority
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("BoardTaskTag", b =>
                {
                    b.Property<Guid>("TagsID")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TasksID")
                        .HasColumnType("TEXT");

                    b.HasKey("TagsID", "TasksID");

                    b.HasIndex("TasksID");

                    b.ToTable("BoardTaskTag");
                });

            modelBuilder.Entity("WPF_Project.Models.BoardColumn", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Columns");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "To Do"
                        },
                        new
                        {
                            ID = 2,
                            Name = "In Progress"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Done"
                        });
                });

            modelBuilder.Entity("WPF_Project.Models.BoardTask", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Column_ID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Priority")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("Column_ID");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("WPF_Project.Models.SubTask", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("Task_ID")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("Task_ID");

                    b.ToTable("SubTasks");
                });

            modelBuilder.Entity("WPF_Project.Models.Tag", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<byte>("Color_A")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Color_B")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Color_G")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Color_R")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            ID = new Guid("5c978646-9aa5-4231-8242-d4dc96a8fa7a"),
                            Color_A = (byte)0,
                            Color_B = (byte)0,
                            Color_G = (byte)0,
                            Color_R = (byte)0,
                            Name = "School"
                        },
                        new
                        {
                            ID = new Guid("85e45b4f-462b-460a-ad0a-c77d9ada38e7"),
                            Color_A = (byte)0,
                            Color_B = (byte)0,
                            Color_G = (byte)0,
                            Color_R = (byte)0,
                            Name = "Project"
                        },
                        new
                        {
                            ID = new Guid("9cf87582-ad39-4531-9614-fcdbf7adeb96"),
                            Color_A = (byte)0,
                            Color_B = (byte)0,
                            Color_G = (byte)0,
                            Color_R = (byte)0,
                            Name = "Exercise"
                        },
                        new
                        {
                            ID = new Guid("e24d1c51-0880-4745-a08a-6ba9f23a41ac"),
                            Color_A = (byte)0,
                            Color_B = (byte)0,
                            Color_G = (byte)0,
                            Color_R = (byte)0,
                            Name = "Shopping"
                        });
                });

            modelBuilder.Entity("BoardTaskTag", b =>
                {
                    b.HasOne("WPF_Project.Models.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WPF_Project.Models.BoardTask", null)
                        .WithMany()
                        .HasForeignKey("TasksID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WPF_Project.Models.BoardTask", b =>
                {
                    b.HasOne("WPF_Project.Models.BoardColumn", "Column")
                        .WithMany("Tasks")
                        .HasForeignKey("Column_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Column");
                });

            modelBuilder.Entity("WPF_Project.Models.SubTask", b =>
                {
                    b.HasOne("WPF_Project.Models.BoardTask", "Task")
                        .WithMany("SubTasks")
                        .HasForeignKey("Task_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Task");
                });

            modelBuilder.Entity("WPF_Project.Models.BoardColumn", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("WPF_Project.Models.BoardTask", b =>
                {
                    b.Navigation("SubTasks");
                });
#pragma warning restore 612, 618
        }
    }
}