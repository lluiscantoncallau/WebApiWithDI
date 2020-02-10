using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApiWithDI.Health;
using WebApiWithDI.Repository;

namespace WebApiWithDI
{
    public class Startup
    {      
        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment env)
        {
            var dom = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json")
                .AddEnvironmentVariables()
                .Build();

            Configuration = dom;
           
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", EnvironmentVariableTarget.User);
            //Comment by generate Migrations
            if (environment == "Production")
            {
                services.AddDbContext<TodoContextSqlServer>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            }
            else
            {
                services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"));
            }
            //services.AddDbContext<TodoContextSqlServer>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
            services.AddHealthChecks().AddCheck<ApiHealthCheck>("api");
            services.AddScoped<EfTodoItemRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
                       
            app.UseHealthChecks("/health", new HealthCheckOptions()
            {                
                ResponseWriter = WriteHealthCheckResponse
            });
        }

        private static Task WriteHealthCheckResponse(HttpContext httpContext, HealthReport result)
        {      
            httpContext.Response.ContentType = "application/json";
            var json = new JObject(
                new JProperty("Environment", Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", EnvironmentVariableTarget.User)),
                //new JProperty("ConnectionString", Configuration.GetConnectionString("DefaultConnection")),
                new JProperty("status", result.Status.ToString()),
                new JProperty("results", new JObject(
                    result.Entries.Select(pair => 
                    new JProperty(pair.Key, 
                    new JObject(
                        new JProperty("status", pair.Value.Status.ToString()), 
                        new JProperty("description", pair.Value.Description), 
                        new JProperty("data",
                        new JObject(pair.Value.Data.Select(p =>
                        new JProperty(p.Key, p.Value))))))))));

            return httpContext.Response.WriteAsync(json.ToString(Formatting.Indented));
        }
    }
}
