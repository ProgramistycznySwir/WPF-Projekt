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
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<SubTask> SubTasks { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Column> Columns { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }


		protected override void OnModelCreating(ModelBuilder bob)
		{
			base.OnModelCreating(bob);

			bob.Entity<Models.Task>()
				    .HasMany<SubTask>(e => e.SubTasks)
                    .WithOne(e => e.Task)
					.HasForeignKey(e => e.Task_ID);
            bob.Entity<Models.Task>()
                    .HasMany<Tag>(e => e.Tags)
                    .WithMany(e => e.Tasks);

            bob.Entity<Models.Task>()
                    .HasOne<Column>(e => e.Column)
                    .WithMany(e => e.Tasks)
                    .HasForeignKey(e => e.Column_ID)
                    .IsRequired();
		}

        private void SeedValues(ModelBuilder bob)
        {

        }
	}
}
