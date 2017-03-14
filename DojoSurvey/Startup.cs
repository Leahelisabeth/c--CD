using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
namespace SurveyApp
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
            app.UseStaticFiles();
            //i needed to tell it to use static files to serve up my views of mt html
            //Use MVC to hand our http req's and res's
            app.UseMvc();//always the last line we execute
        }
    }
}