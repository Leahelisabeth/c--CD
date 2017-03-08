using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //this is where our server starter stuff goes now
            IWebHost host = new WebHostBuilder()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseKestrel()
            .UseStartup<Startup>()//we added this after doing Startup.cs
            .Build();
            host.Run();
        }
    }
}
