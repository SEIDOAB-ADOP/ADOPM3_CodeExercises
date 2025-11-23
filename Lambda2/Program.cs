using System;
using Lambda2.Models;

namespace Lambda2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string newName = "Frank";
            var johnOnly = FriendList.Factory.CreateRandom(100, orgFriend =>
            {
                orgFriend.FirstName = newName;
                return orgFriend;
            });

            var newCity = "Stockholm";
            var gavleOnly = FriendList.Factory.CreateRandom(100, orgFriend => 
            {
                var newAddress = orgFriend.Address;
                newAddress.City = newCity;

                orgFriend.Address = newAddress;
                return orgFriend;
            });

            var friends = FriendList.Factory.CreateRandom(100);
 
            Console.WriteLine("\nHello to Finland");
            friends.SayHello(friend =>
                {
                    if (friend.Address.Country == "Finland")
                    {
                        Console.WriteLine($"Hello {friend.FirstName}, {friend.Address.Country} from Finland");
                    }
                });

            Console.WriteLine("\nHello to Gavle");
            friends.SayHello(friend =>
                {
                    if (friend.Address.City == "Gavle")
                    {
                        Console.WriteLine($"Hello {friend.FirstName}, {friend.Address.City} from Gavle");
                    }
                });

            Console.WriteLine("\nHello to Scandinavia");
            friends.SayHello(friend => 
                {
                    if (friend.Address.Country != "Finland")
                    {
                        System.Console.WriteLine($"Hello {friend.FirstName}, {friend.Address.City} from Scandinavia");
                    }
                });


            Console.WriteLine("\nAlternative Hello to All");
            
            Action<Friend> AllHello = friend =>
                {
                    if (friend.Address.Country == "Finland")
                    {
                        Console.WriteLine($"Hello {friend.FirstName}, {friend.Address.Country} from Finland");
                    }
                };

            AllHello += friend =>
                {
                    if (friend.Address.City == "Gavle")
                    {
                        Console.WriteLine($"Hello {friend.FirstName}, {friend.Address.City} from Gavle");
                    }
                };
            AllHello += friend => 
                {
                    if (friend.Address.Country != "Finland")
                    {
                        System.Console.WriteLine($"Hello {friend.FirstName}, {friend.Address.City} from Scandinavia");
                    }
                };


            friends.SayHello(AllHello);

        }
        /*

        public static void HelloFinland(Friend friend)
        {
            if (friend.Address.Country == "Finland")
            {
                Console.WriteLine($"Hello {friend.FirstName}, {friend.Address.Country} from Finland");
            }
        }
        public static void HelloGavle(Friend friend)
        {
            if (friend.Address.City == "Gavle")
            {
                Console.WriteLine($"Hello {friend.FirstName}, {friend.Address.City} from Gavle");
            }
        }
        public static void HelloScandinavia(Friend friend)
        {
            if (friend.Address.Country != "Finland")
            {
                Console.WriteLine($"Hello {friend.FirstName}, {friend.Address.Country} from Scandinavia");
            }
        }

        public static Friend AllJohn(Friend orgFriend)
        {
            orgFriend.FirstName = "John";
            return orgFriend;
        }

        public static Friend AllGavle(Friend orgFriend)
        {
            var newAddress = orgFriend.Address;
            newAddress.City = "Gavle";

            orgFriend.Address = newAddress;
            return orgFriend;
        }
        */
        public static Friend AllJohn(Friend orgFriend)
        {
            orgFriend.FirstName = "John";
            return orgFriend;
        }
    }
}

//Exercise
// 1. In Main() Convert all Delegates into Lambda Expressions.