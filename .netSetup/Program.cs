using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace SetupApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost host = new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                //UseContentRoot tells orur webserver where to find the porject files
                .UseKestrel()
                //tells our webhost we made to use kestrel- so we can use localhost easily
                .UseStartup<Startup>()
                .Build();
                //completes the initialization of our webhost
            host.Run();
            //finally we start up webhost and the web app
            
        }
    }
}
//the main area is our apps entry point now, 
//this will now spin up our server and no longer contain our logic.