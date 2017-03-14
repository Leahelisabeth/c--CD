using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;

namespace ConsoleApplication
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //Service added for MVC
            services.AddMvc();
        }
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            //Logger
            loggerFactory.AddConsole();
            //Use Static Files
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            // app.Run(async context =>
            // {
            //     await context.Response.WriteAsync();
            // });
            app.UseMvc( routes => 
            routes.MapRoute(
                name: "Default",
                template: "Index",
                defaults: new {controller = "Hello", action = "Index"}
            ));//always be the last line we execute when adding more junk in this space
        }
    }
}