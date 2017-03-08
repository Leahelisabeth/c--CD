using System;
using System.Collections.Generic; //remember to have this line for lists and dictionaries;
//if you change using you must run restore again
namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            string[] basicArray = {"Tim", "Martin", "Sara"};
            int[] intArray = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            bool[] boolArray = new bool[10];
            bool output = true;
            for (int i = 0; i < 10; i++)
            {
                boolArray[i]=output;
                output=!output;
                System.Console.WriteLine(boolArray[i]);
            }
            Console.WriteLine(boolArray);
            int[,] multiTable = new int [10, 10];
            for (int x = 1; x < 11; x++)
            {
                for (int y = 1; y < 11; y++)
                {
                    multiTable [x-1,y-1]=x*y;
                }
            }
            List<string> flavors = new List<string>();
            flavors.Add("Vanilla");
            flavors.Add("Chocolate");
            flavors.Add("Cookie Dough"); //it had problems when i tried to do ''/ mayeb because i mixed single and double?
            flavors.Add("Neopolitan");
            flavors.Add("Birthday Cake");
            System.Console.WriteLine(flavors.Count);
            System.Console.WriteLine(flavors[2]);
            flavors.RemoveAt(2);
            System.Console.WriteLine(flavors.Count);

            //create dictionary that stores string keys and string values, for each name in the array of names. for each name in the array of names you made previously add it as a key in this
            //new dictionary. for each nmae key select a random flavor from the list above and store it as the value/ loop through dictionary and print the names with the flavor
            Dictionary<string,string> favs = new Dictionary<string,string>();
            Random rand = new Random();
            foreach(string name in basicArray){
                favs[name] = flavors[rand.Next(flavors.Count)];
            }
            foreach (KeyValuePair<string,string> entry in favs){
                System.Console.WriteLine(entry.Key + entry.Value);  //for some reason putting a comma between thses didnt let it print.
                          }
        }//end of main
    }
}
