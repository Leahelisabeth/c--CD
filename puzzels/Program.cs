using System;
using System.Collections.Generic;
//dotnet restore fetches dependencies in project.json
namespace ConsoleApplication
{
    public class Program 
    {//where we create functions--in order for the function to be a part of our program it must be in here.
    //what is public static?
    //you need to decalre what the function is returning, whether its static, and whether its private or public function. //look up private v. public funcs.
        public static int[] RandomArray(){//not all code paths return a value-- our functions not returning anything is error
            int[] myArray = new int[10];
            Random rand = new Random();
            for (int i =0; i<10; i++){
                myArray[i] = rand.Next(5, 26);//beginning # inclusive and seocnd is exclusive
            }
            return myArray;
        }
        //create coin toss function
        public static string CoinToss(){
            string result = "heads";
            System.Console.WriteLine("tossing a coin...");
            Random rando = new Random();
            int toss = rando.Next(0,2);
            if (toss == 1){
                result = "tails";
                
            } 
            return result;
        }
        //create 
        public static double TossManyCoin(int num){
            Random randy = new Random();
            int numheads = 0;
            for(int i=0; i<num; i++){
                
                if(randy.Next()%2 ==0){
                    numheads++;
                }
            }
            return (double)numheads/num;
        }
        public static string[] Names(){
            string[] names = {"leah", "joey", "rachel", "Ross", "Charlie"};
            Random rando = new Random();
            for(var idx = 0; idx < names.Length-1; idx++){
                int randIdx = rando.Next(idx +1, names.Length-1);
                string temp = names[idx];
                names[idx] = names[randIdx];
                names[randIdx] = temp;
                System.Console.WriteLine(names[idx]);

            }
            List<string> shorties = new List<string>();
            foreach(string name in names){
                if(name.Length > 5){
                    shorties.Add(name);
                }
            }
            string[] newArray = shorties.ToArray();
            return newArray;
        }
        public static void Main(string[] args)
        {
            //one, creat function called random array that return an integer array
            RandomArray();//why do we call our functyion here? this is whats being executed, the main section.
            CoinToss();
            TossManyCoin(8);
            Names();

            //toss coin and get heads and tails
            //Console.WriteLine("Hello World!");
        }
    }
}
