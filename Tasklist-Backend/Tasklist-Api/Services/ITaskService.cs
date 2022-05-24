using Tasklist.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tasklist.Api.Services
{
	public interface ITaskService
	{
		IEnumerable<TaskItem> GetAll();
		IEnumerable<TaskItem> Generate(int tasksNumber);
		void Update(int id, TaskItem task);
	}
}
