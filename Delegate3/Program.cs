// See https://aka.ms/new-console-template for more information
using System.Net.Security;
using System.Runtime.Intrinsics.Arm;
using Delegate3;

Console.WriteLine("Hello, Friends!");

var friends = new FriendList(10);
System.Console.WriteLine(friends);

//program.cs
friends
    .ConfigureEmail(option =>
    {
        if (option.Car.Color == CarColor.Green)
        {
            return $"Dear {option.FirstName}, your car is ugly {option.Car.Color}, pls come to the shop for a paint job!";
        }
        return $"Dear {option.FirstName}. Congratulations, to an excellent choice of a {option.Car.Color} car!";
    })
    .ConfigureEmail(option => {
        if (option.Car.Color == CarColor.Red)
        {
            return $"Dear {option.FirstName}, your car is ugly {option.Car.Color}, pls come to the shop for a paint job!";
        }
        return $"Dear {option.FirstName}. Congratulations, to an excellent choice of a {option.Car.Color} car!";
    });



//sometimes later....
var emails = friends.Emails();

foreach (var item in emails)
{
    System.Console.WriteLine(item);
}







/*
var s = Greetings ("Gandalf", 75);
System.Console.WriteLine(s);

var f = (string name, int age) =>
{
    return $"{name}, happy {age}!";
};


var s1= f("Hermoine", 35);
System.Console.WriteLine(s1);



string Greetings(string name, int age)
{
    return $"Hello {name}, happy {age} birthday!";
}

string Greetings1(string name, int age)
{
    return $"{name}, happy {age}!";
}
*/

