using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace BlankApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession();
            //tell it to add session
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
            app.UseSession();
            //tell it to use session
            //i needed to tell it to use static files to serve up my views of mt html
            //Use MVC to hand our http req's and res's
            app.UseMvc();//always the last line we execute
        }
    }
}
//SESSION NOTES:
//  There are some limitations to the kind of data we can store in session. 
//  In ASP.NET Core MVC we can only use the session to hold on to integers 
//  and strings by default. We have to specify what kind of 
//  data the session contains both when we set it, and when we retrieve it.
//CLEAR OUT SESSION: 
//HttpContext.Session.Clear();
