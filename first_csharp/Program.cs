﻿using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // int sum = 0;
            // for (int i = 1; i <= 255; i++){
            //     Console.WriteLine(i);
            
            // }
        //     int num = 0;
        //     for (int i = 1; i <= 100; i++){
        //         if (i % 3 == 0 || i % 5 == 0){
        //             if( i % 3 == 0 && i % 5 == 0 ){
        //                continue;
        //             }
        //             else{
        //                 Console.WriteLine(i);
        //             }
        //         }
        // }
             //int num = 0;
        //     for (int i = 1; i <= 100; i++){
        //         if (i % 3 == 0){
        //             Console.WriteLine("Fizz");
        //         }
        //         else if (i % 5 == 0){
        //             Console.WriteLine("Buzz");
        //         }
        //         if (i % 5 == 0 && i % 3 ==0){
        //             Console.WriteLine("FizzBuzz");
        //         }
        // }
         Random rand = new Random();
         for (int num = 0; num <= 100; num++){
             int i = rand.Next(1, 100);
                if (i % 3 == 0){
                    Console.WriteLine("Fizz");
                }
                else if (i % 5 == 0){
                    Console.WriteLine("Buzz");
                }
                if (i % 5 == 0 && i % 3 ==0){
                    Console.WriteLine("FizzBuzz");
                }
         }

    }
}
}
