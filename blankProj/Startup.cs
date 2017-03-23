using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BlankApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddCaching();
            //from internet
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
    public static class SessionExtensions
    {
        // We can call ".SetObjectAsJson" just like our other session set methods, by passing a key and a value
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            // This helper function simply serializes theobject to JSON and stores it as a string in session
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        // generic type T is a stand-in indicating that we need to specify the type on retrieval
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            string value = session.GetString(key);
            // Upone retrieval the object is deserialized based on the type we specified
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
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
