using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {//print 1-255
    public static int print(){
        int num =0;
        for(int i = 1; i<256; i++){
            System.Console.WriteLine(i);
            num =i;
            
        }
        return num;
    }
    //print odds 1-255
    public static int printOdds(){
        int num =0;
        for(int i = 1; i<256; i+=2){
            System.Console.WriteLine(i);
            num =i;
            
        }
        return num;
    }

    //print sum 1-255
    public static int printSum(){
        int sum =0;
        for(int i = 1; i<256; i++){
            sum +=i;
            
        }
        System.Console.WriteLine(sum);
        return sum;
    }
    //iterate through an array and print its vals
    public static void arrayVals(int[] arr){
        for(int i = 0; i<arr.Length; i++){
            System.Console.WriteLine(arr[i]);
        }
    }
    //find max, 
    public static int findmax(int[] arr){
        int max = arr[0];
        for(int i = 0; i <arr.Length; i++){
            if(arr[i] > max){
                max = arr[i];
            }
        }
        System.Console.WriteLine(max);
        return max;
    }
    //get avg
    public static int printAvg(int[] arr){
        int sum =0;
        for(int i = 1; i<arr.Length; i++){
            sum +=arr[i];
            
        }
        int avg = sum/arr.Length;
        System.Console.WriteLine(avg);
        return avg;
    }
    //array with odds
      public static int[] OddArray(){
        List<int> newlist = new List<int>();
        for(int i = 1; i<256; i+=2){
            newlist.Add(i);
        }
        int[] mynewArray = newlist.ToArray();
        return mynewArray;
    }
    //greater than y
    public static int grtrY(int[] arr, int val){
        int counter = 0;
        for(int i = 0; i <arr.Length; i++){
            if(arr[i] > val){
                counter++;
            }
        }
        System.Console.WriteLine(counter);
        return counter;
    }

    //square vals
    public static int[] sqrVals(int[] arr){
        for(int i = 0; i <arr.Length; i++){
            arr[i] *= arr[i];
        }
        System.Console.WriteLine(arr);
        return arr;
    }

    //eliminate negs
 public static int[] noNeg(int[] arr){
    
        for(int i = 1; i<arr.Length; i++){
            if(arr[i] < 0){
                arr[i]=0;
            }
            
        }
        return arr;
    }
    //mn, max avg
    //shift vals
     public static int[] shiftarr(int[] arr){
        for(int i = 0; i<arr.Length; i++){
            if(i == arr.Length-1){
                continue;
            }
            arr[i] = arr[i+1];
        }
        arr[arr.Length-1] = 0;
        System.Console.WriteLine(arr);
        return arr;
    }
    //number to string in array.
     public static object[] arrStr(object[] arr){
        
        for(int i = 0; i<arr.Length; i++){
            if((int)arr[i] < 0){
                arr[i]= "Dojo";
            }
            
        }
        return arr;
    }
        public static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            print();
            printOdds();
            printSum();
            int[] myarray = {1, 4, -4, 6, 90, 13, -3};
            object[] myOarray = {1, 4, -4, 6, 90, 13, -3};
            printAvg(myarray);
            arrayVals(myarray);
            findmax(myarray);
            grtrY(myarray, 10);
            noNeg(myarray);
            shiftarr(myarray);
            arrStr(myOarray);
        }//end main
    }
}
