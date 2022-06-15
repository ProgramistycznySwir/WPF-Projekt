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
    [Migration("20220603084237_AddedColorToTags")]
    partial class AddedColorToTags
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("TagTask", b =>
                {
                    b.Property<Guid>("TagsID")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TasksID")
                        .HasColumnType("TEXT");

                    b.HasKey("TagsID", "TasksID");

                    b.HasIndex("TasksID");

                    b.ToTable("TagTask");
                });

            modelBuilder.Entity("WPF_Project.Models.Column", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Columns");
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
                });

            modelBuilder.Entity("WPF_Project.Models.Task", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("Column_ID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("Column_ID");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("TagTask", b =>
                {
                    b.HasOne("WPF_Project.Models.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WPF_Project.Models.Task", null)
                        .WithMany()
                        .HasForeignKey("TasksID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WPF_Project.Models.SubTask", b =>
                {
                    b.HasOne("WPF_Project.Models.Task", "Task")
                        .WithMany("SubTasks")
                        .HasForeignKey("Task_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Task");
                });

            modelBuilder.Entity("WPF_Project.Models.Task", b =>
                {
                    b.HasOne("WPF_Project.Models.Column", "Column")
                        .WithMany("Tasks")
                        .HasForeignKey("Column_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Column");
                });

            modelBuilder.Entity("WPF_Project.Models.Column", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("WPF_Project.Models.Task", b =>
                {
                    b.Navigation("SubTasks");
                });
#pragma warning restore 612, 618
        }
    }
}