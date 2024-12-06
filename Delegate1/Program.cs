﻿using System;
using System.Collections.Generic;

namespace Delegate1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Starting point
            Console.WriteLine("Starting point");
            List<int> numbers = new List<int>();
            List<string> cities = new List<string>();

            //Random Initialization
            var rnd = new Random();
            var names = "Stockholm, Copenhagen, Oslo, Helsinki, Berlin, Madrid, Lissabon".Split(", ");
            for (int i = 0; i < 10; i++)
            {
                numbers.Add(rnd.Next(100, 1000 + 1));
                cities.Add(names[rnd.Next(0, names.Length)].Trim());
            }
            #endregion

            #region Exercises 1-4
            Console.WriteLine("Delegates I Exercises");
            #endregion

            #region Exercises 5-6
            Console.WriteLine("\nDelegates II Exercises");
            #endregion

            #region Exercises 7-8
            Console.WriteLine("\nDelegates III Exercises");
            #endregion
        }
    }
}
//Exercises

//Delegates I
//1.  Explore List<>.ForEach and write a delegate that prints numbers to the console using List<>.ForEach()
//2.  Explore List<>.ForEach and write a delegate that prints cities to the console using List<>.ForEach()

//Delegates II
//5.  Explore List<>.FindAll and write a delegate returns a List of all even numbers.
//6.  Explore List<>.FindAll and write a delegate returns a List of all cities with a name with more than 6 letters.

//Delegates III
//7. Explore List<>.Find() and write a delegate that finds the first number in numbers > 500. Print out the number
//8. Explore List<>.FindLast() and write a delegate that finds the last city in the cities with a name longer than 8 letters


