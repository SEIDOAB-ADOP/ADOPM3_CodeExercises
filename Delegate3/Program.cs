// See https://aka.ms/new-console-template for more information
using System.Net.Security;
using System.Runtime.Intrinsics.Arm;
using Delegate3;

Console.WriteLine("Hello, Friends!");

var friends = new FriendList(10);
System.Console.WriteLine(friends);

//program.cs
friends
    .ConfigureEmail("CarRecall", CarRecall)
    .ConfigureEmail(name: "WeddingInvite", configureEmail: WeddingInvite);


//later in another galaxy far far away...
System.Console.WriteLine("\nCarRecall");
var emails = friends.Emails("CarRecall");
foreach (var item in emails)
{
    System.Console.WriteLine(item);
}

System.Console.WriteLine("\nWeddingInvite");
emails = friends.Emails("WeddingInvite");
foreach (var item in emails)
{
    System.Console.WriteLine(item);
}



string CarRecall (Friend friend)
    {
        if (friend.Car.Color == CarColor.Green)
        {
            return $"Dear {friend.FirstName}, your car is ugly {friend.Car.Color}, pls come to the shop for a paint job!";
        }
        return $"Dear {friend.FirstName}. Congratulations, to an excellent choice of a {friend.Car.Color} car!";
    }

string WeddingInvite (Friend friend)
    {
        return $"Dear {friend.FirstName}. Please join us in celebrating our wedding!";
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

