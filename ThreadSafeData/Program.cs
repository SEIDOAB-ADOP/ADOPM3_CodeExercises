using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSafeData
{
    class Program
    {

        //Thread Safe Datastructure
        public class VehicleStorage
        {
            private readonly Random _rnd = new Random();
            private readonly List<Vehicle> _vehicles = new List<Vehicle>();

            public void SetData (string regNr, string owner)
            {
                //Do something with regNr and owner before writing to the list
                string anotherRegNr = regNr;
                string anotherOwner = owner;
                Task.Delay(_rnd.Next(1, 5)).Wait();

                if ((anotherRegNr, anotherOwner) != ("ABC 123", "Kalle Anka") &&
                    (anotherRegNr, anotherOwner) != ("HKL 556", "Musse Pigg"))
                       System.Console.WriteLine($"RegNr: {anotherRegNr}, Owner: {anotherOwner}");


                var v = new Vehicle() {RegistrationNumber = anotherRegNr, Owner = anotherOwner};
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
            
            public class Vehicle
            {
                public string RegistrationNumber { get; set; }
                public string Owner { get; set; }
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
                    myCar.SetData("ABC 123", "Kalle Anka");
                    Task.Delay(rnd.Next(1, 5)).Wait();
                    
                    myCar.GetData(i);
                }
                Console.WriteLine("t1 Finished");
            });

            var t2 = Task.Run(() =>
            {
                var rnd = new Random();
                for (int i = 0; i < 1000; i++)
                {
                    //Write Data to Vehicle, "HKL 556", "Musse Pigg"
                    myCar.SetData("HKL 556", "Musse Pigg");
                    Task.Delay(rnd.Next(1, 5)).Wait();
                    
                    myCar.GetData(i);
                }
                Console.WriteLine("t2 Finished");
            });

            Task.WaitAll(t1, t2);
            Console.WriteLine("All Finished");

            //Check data consistency
            if (!myCar.CheckConsistency())
            {
                Console.WriteLine("Data inconsistent!");
            }
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
