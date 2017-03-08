using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            Human leah = new Human("Leah");
            Human elise = new Human("Elise");
            leah.Attack(elise);

            System.Console.WriteLine(elise.health);
        }
    }
}
