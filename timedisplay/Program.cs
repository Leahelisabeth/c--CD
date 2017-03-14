using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace TimeApp
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
