using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Deck mycards = new Deck();
            mycards.shuffle();
            System.Console.WriteLine(mycards.cards);
        }
    }
}
