using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Tasklist.Api.Data;
using Tasklist.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace Tasklist.Api.Services
{
	public class TaskService : ITaskService
	{
		private readonly TaskListContext context;

		public TaskService(TaskListContext ctx)
		{
			context = ctx;
		}

		public IEnumerable<TaskItem> GetAll()
		{
			var tasks = context.TaskItems.ToList<TaskItem>();
			return tasks ?? Generate(3);
		}

		public IEnumerable<TaskItem> Generate(int taskNumber)
		{
			for (int i = 0; i < taskNumber; i++)
			{
				var task = new Tasklist.Api.Models.TaskItem()
				{
					Title = GetTitle(),
					Completed = false,
				};

				context.Add(task);
				context.SaveChanges();

				context.TaskLogs.Add(new TaskLog() { TaskId = task.Id, Action = Action.Created.ToString(), ActionDate = DateTime.Now });
				context.SaveChanges();
			}

			return GetAll();
		}

		public void Update(int id, TaskItem task)
		{
			try
			{
				context.Update(task);

				context.TaskLogs.Add(new TaskLog() { TaskId = task.Id, Action = Action.Completed.ToString(), ActionDate = DateTime.Now });

				context.SaveChanges();
			}
			catch
			{
				throw;
			}
		}

		public static string GetTitle()
		{
			//Fetch the title string from URL.
			string apiUrl = "https://hipsum.co/api/?type=hipster-latin&sentences=1";

			string[] title = null;

			HttpClient client = new HttpClient();

			HttpResponseMessage response = client.GetAsync(apiUrl).Result;

			if (response.IsSuccessStatusCode)
			{
				title = JsonConvert.DeserializeObject<string[]>(response.Content.ReadAsStringAsync().Result);
			}

			return (title != null && title.Length > 0) ? title.FirstOrDefault() : "";
		}
	}

	public enum Action
	{
		Created,
		Completed
	}
}
