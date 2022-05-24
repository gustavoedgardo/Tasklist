using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tasklist.Api.Models
{
	public class TaskItem
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public bool Completed { get; set; }
	}
}
