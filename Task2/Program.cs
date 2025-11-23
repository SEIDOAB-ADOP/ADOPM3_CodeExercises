// See https://aka.ms/new-console-template for more information

using System;

namespace Task2
{ 
    internal class Program
    {
        static void Main(string[] args)
        {
            string s1 = null, s2 = null, s3 = null;
            List<Task<string>> tasks = new List<Task<string>>();
            try
            {
                Console.WriteLine("Syncron calls");
                s1 = SayHello("Good Morning", 10, 1000, false);
                s2 = SayHello("Good Afternoon", 5, 2000, false);
                s3 = SayHello("Good Evening", 15, 500, false);

                Console.WriteLine(s1);
                Console.WriteLine(s2);
                Console.WriteLine(s3);

                //Ex3 - make the calls to SayHelloAsync
                Console.WriteLine("\n\nAsyncron calls");

                //Ex3 - Wait for all tasks to complete
            }
            catch (Exception ex)
            {
                //Your code
                Console.WriteLine(ex.Message);
                foreach (var item in tasks)
                {
                    Console.WriteLine(item.IsFaulted);
                }
            }
            finally
            {
                Console.WriteLine("Main terminated");
                foreach (var item in tasks)
                {
                    if (item.IsCompletedSuccessfully)
                    Console.WriteLine(item.Result);
                }
                Console.ReadLine();
            }
        }

        //Ex2 - complete below async declaration of SayHello 
        //static public Task<string> SayHelloAsync(string message, int iterations, int msDelay, bool causeError = false) => ....
        static public string SayHello(string message, int iterations, int msDelay, bool causeError = false)
        {
            var rnd = new Random();
            int errorIteration = rnd.Next(0, iterations);
            for (int i = 0; i< iterations; i++)
            {
                Console.WriteLine($"{i,4}:{message}");
                Task.Delay(msDelay);
                
                if (causeError && (i == errorIteration))
                {
                    throw new Exception($"Error saying: {message}");
                }
            }
            return $"All good saying: {message}";
        }
    }
}

//Exercise:
//1. Run above code and set causeError flag to true for SayHello calls Good Morning, Good Afternoon, Good Evening
//   - discuss and understand the Error handling
//   - set all causeError to false to continue to Ex2

//2. Make SayHello asyncronous by having it run in it's own Task
//   - finish the declaration above

//3. Call SayHelloAsync for Good Morning, Good Afternoon, Good Evening
//   - let them run as parallell tasks and wait for all to finish
//   - cause some errors in all three SayHelloAsync and see how the errorhandling is processed
//   - can you determine when the various tasks did the error throw by checking the output
//   - set all causeError to false to continue to Ex4

//4. Move the  Console.WriteLine(t.Result); to happen after each t = SayHelloAsync(...)
//   - cause some errors in one of the SayHelloAsync and see how the errorhandling is processed
//   - cause some errors in all of the SayHelloAsync and see how the errorhandling is processed







