using Tasklist.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tasklist.Api.Data
{
	public static class DbInitializer
	{
		public static void Initialize(TaskListContext context)
		{
			context.Database.EnsureCreated();

			// Look for any task.
			if (context.TaskItems.Any())
			{
				return;   // DB has been seeded
			}

			//var tasksItems = new TaskItem[]
			//{
			//new TaskItem{Title="Quis reprehenderit direct trade affogato adipisicing shabby chic +1", Completed=false},
			//new TaskItem{Title="Adaptogen deep v iPhone poutine.", Completed=false},
			//new TaskItem{Title="Affogato labore hexagon, blog kinfolk enim laborum roof party pitchfork.", Completed=false},
			//new TaskItem{Title="Lorem subway tile single-origin coffee migas quinoa chambray in vinyl.", Completed=false},
			//new TaskItem{Title="Fugiat poutine ennui street art.", Completed=false},
			//new TaskItem{Title="Esse single-origin coffee tote bag sed four loko butcher labore waistcoat mlkshk pariatur paleo vape hoodie pinterest.", Completed=false},
			//new TaskItem{Title="Beard wolf live-edge, etsy shaman typewriter franzen cray food truck.", Completed=false}
			//};

			//foreach (TaskItem t in tasksItems)
			//{
			//	context.TaskItems.Add(t);
			//}

			//context.SaveChanges();
		}
	}
}
