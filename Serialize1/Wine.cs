using System;
using Seido.Utilities.SeedGenerator;
using Seido.Utilities.ConsoleInput;

namespace _05_Wines_Interfaces
{
    public enum GrapeType { Reissling, Tempranillo, Chardonay, Shiraz, CabernetSavignoin, Syrah }
    public enum WineType { Red, White, Rose }
    public enum Country { Germany, France, Spain }

    public class Wine
	{
        public string Name { get; set; }

        public Country Country { get; set; }
        public WineType WineType { get; set; }
        public GrapeType GrapeType { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
            => $"Wine {Name} from {Country} is {WineType} and made from grapes {GrapeType}."
            + $" The price is {Price:N2} Sek. ({this.GetType().Name})";


        public Wine Seed (SeedGenerator rnd)
        {
            Name = rnd.FromString("Chattaux de bueff, Chattaux de paraply, PutiPuti, NamNam");

            GrapeType = rnd.FromEnum<GrapeType>();
            WineType = rnd.FromEnum<WineType>();
            Country = rnd.FromEnum<Country>();
            Price = rnd.Next(50, 150);
            return this;
        }

        public Wine(Wine original)
        {
            this.Name = original.Name;
            this.GrapeType = original.GrapeType;
            this.Country = original.Country;
            this.WineType = original.WineType;
            this.Price = original.Price;
        }
        public Wine()
        {

        }
	}
}

