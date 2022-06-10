using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WPF_Project.Models;

namespace WPF_Project.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<BoardTask> Tasks { get; set; }
        public DbSet<SubTask> SubTasks { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BoardColumn> Columns { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }


		protected override void OnModelCreating(ModelBuilder bob)
		{
			base.OnModelCreating(bob);

			bob.Entity<BoardTask>()
				    .HasMany<SubTask>(e => e.SubTasks)
                    .WithOne(e => e.Task)
					.HasForeignKey(e => e.Task_ID);
            bob.Entity<BoardTask>()
                    .HasMany<Tag>(e => e.Tags)
                    .WithMany(e => e.Tasks);

            bob.Entity<BoardTask>()
                    .HasOne<BoardColumn>(e => e.Column)
                    .WithMany(e => e.Tasks)
                    .HasForeignKey(e => e.Column_ID)
                    .IsRequired();
            SeedValues(bob);
		}

        private void SeedValues(ModelBuilder bob)
        {
            bob.Entity<BoardColumn>().HasData(
                    new BoardColumn { ID= 1, Name= "To Do" },
                    new BoardColumn { ID= 2, Name= "In Progress" },
                    new BoardColumn { ID= 3, Name= "Done" }
                );
            bob.Entity<Tag>().HasData(
                    new Tag { ID= Guid.NewGuid(), Name= "School" },
                    new Tag { ID= Guid.NewGuid(), Name= "Project" },
                    new Tag { ID= Guid.NewGuid(), Name= "Exercise" },
                    new Tag { ID= Guid.NewGuid(), Name= "Shopping" }
                );
        }
	}
}
