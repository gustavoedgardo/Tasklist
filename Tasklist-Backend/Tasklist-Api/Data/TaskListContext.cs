using Microsoft.EntityFrameworkCore;
using Tasklist.Api.Models;

namespace Tasklist.Api.Data
{
	public class TaskListContext : DbContext
	{
		public TaskListContext(DbContextOptions<TaskListContext> options) : base(options)
        {
		}

		public DbSet<TaskItem> TaskItems { get; set; }
		public DbSet<TaskLog> TaskLogs { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<TaskItem>().ToTable("TaskItem");
			modelBuilder.Entity<TaskLog>().ToTable("TaskLog");
		}
	}
}
