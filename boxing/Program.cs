using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //using boxing we can construct a list of one data type that holds data of different data type.
            //the way it works is that almost all types can be cast to the generic object type.
            //if you construct a list type object you will be able to hold varying types in one collection. 
            //we just must make sure thatr when working in any data collection of this type we must be sure to cast it back to its original type when retrieving it.
            //if we dont cast of unbox the items in our List when we retreive them ou code will only be able to treat them aas if they were type object
            //Safely Unboxing:
                //boxing/unboxing is poweful but dangerous.
                //if you were to unbox something then try to cast it to a data-type that is can not conform to the proram will break at runtime even tho the compiler may
                //allow the operation at build-time. 
                //the simplest way to make sure the value works for the type you are tying to cast it to is to Leverage it using the //*is*// keyword.
            //is:
                object BoxedData = "this is a string";
                if(BoxedData is int){
                    System.Console.WriteLine("this is an int");
                }
                if(BoxedData is string){
                    System.Console.WriteLine("this is a string in the box");
                }
                //is keyword lets us discern the real type of an object when we unbox it. but to actually treat it as the type is is we must then cast it.
            //Explcit Casting after discenring type with is:
                object astring = "a string";
                string explcitString = astring as string;
                //some data types cant be explict cast to:
                    //object anInt = 256; <-- THIS DOESNT WORK!
                    //int ExplicitInt = anInt as int;
            //1.create an empty list of object type
            List<object> chairnum = new List<object>();
            //2.add the following values to the list: 7-28, true, "chair"
            chairnum.Add(7);
            chairnum.Add(28);
            chairnum.Add(-1);
            chairnum.Add(true);
            chairnum.Add("chair");
            int sum = 0;
            for (var idx =0; idx < chairnum.Count; idx++){
                if (chairnum[idx] is int){
                int intChair = (int)chairnum[idx];
                
                sum += intChair;
                }
                System.Console.WriteLine(chairnum[idx]);
                
            }
            System.Console.WriteLine(sum);
            
            //3.loop through list and print values, type inference may help.
            //4.add int types together 
            //Console.WriteLine("Hello World!");

        }
    }
}
