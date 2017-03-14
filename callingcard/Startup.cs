using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
namespace SetupApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //Service added for MVC
            services.AddMvc();
            //service now available across our whole app, we can now .usestartup in our
            //program.cs
        }
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            //Logger
            loggerFactory.AddConsole();
            app.UseDeveloperExceptionPage();
            //Use MVC to hand our http req's and res's
            app.UseMvc();//always the last line we execute
        }
    }
}