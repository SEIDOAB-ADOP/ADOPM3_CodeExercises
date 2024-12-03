using Seido.Utilities.SeedGenerator;

namespace Delegate3;

public enum FriendLevel { Friend, ClassMate, Family, BestFriend }
public class Friend
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string Email { get; set; }
    public FriendLevel Level { get; set; }

    public Car Car { get; set; }
        

    public override string ToString()
    {
        var sRet = $"{FirstName} {LastName} is my {Level} and can be reached at {Email}.";
        if (Car != null)
        {
            sRet += $"\n -{FirstName}'s car is a {Car.Color} {Car.Brand} {Car.Model} from year {Car.YearModel}";
        }
        return sRet;
    }

    public Friend Seed(SeedGenerator seeder)
    {
        string _firstName = seeder.FirstName;
        string _lastName = seeder.LastName;

        return new Friend(){
            FirstName = _firstName,
            LastName = _lastName,

            Email = seeder.Email(_firstName, _lastName),
            Level = seeder.FromEnum<FriendLevel>(),
            Car = new Car().Seed(seeder)};
    }
}
