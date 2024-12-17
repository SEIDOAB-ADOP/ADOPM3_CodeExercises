using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSafeData
{
    class Program
    {
        public class Vehicle
        {
            public string RegistrationNumber { get; set; }
            public string Owner { get; set; }
        }

        //Thread Safe Datastructure
        public class VehicleStorage
        {
            List<Vehicle> _vehicles = new List<Vehicle>();

            public void SetData (string regNr, string owner)
            {
                var v = new Vehicle() { RegistrationNumber = regNr, Owner = owner };
                _vehicles.Add(v);
            }

            public Vehicle GetData (int idx)
            {
                return _vehicles[idx];
            }

            public bool CheckConsistency()
            {
                foreach (var v in _vehicles)
                {
                    if ((v.RegistrationNumber, v.Owner) != ("ABC 123", "Kalle Anka") &&
                        (v.RegistrationNumber, v.Owner) != ("HKL 556", "Musse Pigg"))
                    {
                        //Verify data consistency - write error if not consistent
                        System.Console.WriteLine($"RegNr: {v.RegistrationNumber}, Owner: {v.Owner}");
                        return false;
                    }
                }
                return true;
            }
        }

        static void Main(string[] args)
        {
            var myCar = new VehicleStorage();
            var rnd = new Random();

            var t1 = Task.Run(() =>
            {
                var rnd = new Random();
                for (int i = 0; i < 1000; i++)
                {
                    //Write Data to Vehicle, "ABC 123", "Kalle Anka"

                    //introduce some random system delay between 1 and 5 milliseconds
                    Task.Delay(rnd.Next(1, 5)).Wait();

                    //Read Data from Vehicle

                    //Check data consistency
                    if (!myCar.CheckConsistency())
                    {
                        Console.WriteLine("Data inconsistent!");
                    }
                }
                Console.WriteLine("t1 Finished");
            });

            var t2 = Task.Run(() =>
            {
                var rnd = new Random();
                for (int i = 0; i < 1000; i++)
                {
                    //Write Data to Vehicle, "HKL 556", "Musse Pigg"

                    //introduce some random system delay between 1 and 5 milliseconds

                    //Read Data from Vehicle

                    //Verify data consistency - give error if not consistent
                }
                Console.WriteLine("t2 Finished");
            });

            Task.WaitAll(t1, t2);
            Console.WriteLine("All Finished");
        }


    }
}
/*  Exercise
    1.  - Have task t1 write 1000 times "ABC 123", "Kalle Anka" to myCar
        - Have task t2 write 1000 times "HKL 556", "Musse Pigg" to myCar
        - Verify data consistency
        - Discuss in the group what is data consistency in case of class Vehicle. Is your code living up to it?

    2. Make class Vehicle Thread safe using lock(...)
        - Verify data consistency
        - Discuss in the group what is data consistency in case of class Vehicle. Is your code living up to it?

*/
