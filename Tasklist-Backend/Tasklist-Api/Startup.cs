using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tasklist.Api.Data;
using Tasklist.Api.Services;

namespace Tasklist.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

			services.AddScoped<ITaskService, TaskService>();

			services.AddDbContext<TaskListContext>(options =>
			options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

			services.AddDatabaseDeveloperPageExceptionFilter();

			services.AddMvc(options => options.EnableEndpointRouting = false);

			services.AddCors(o => o.AddPolicy("ReactPolicy", builder =>
			{
				builder.AllowAnyOrigin()
					   .AllowAnyMethod()
					   .AllowAnyHeader();

			}));

			services.AddCors(options =>
			{
				options.AddDefaultPolicy(builder =>
				{
					builder.WithOrigins("http://localhost:3000");
				});
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}
			app.UseRouting();
			app.UseCors("ReactPolicy");
			app.UseHttpsRedirection();
			app.UseMvc();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
