using Seido.Utilities.SeedGenerator;

namespace Delegate3;

public class FriendList
{
    public  List<Friend> MyFriends = new List<Friend>();

    private Dictionary<string,Func<Friend, string>> _emailOptions = new Dictionary<string, Func<Friend, string>>();

    public FriendList ConfigureEmail (string name, Func<Friend, string> configureEmail)
    {
        _emailOptions.Add(name, configureEmail);
        return this;
    }

    public override string ToString()
    {
        string sRet = "";
        foreach (var item in MyFriends)
        {
            sRet += item.ToString() + "\n";
        }
        return sRet;
    }

    public FriendList(int nrOfFriends)
    {
        var rnd = new SeedGenerator();
        for (int i = 0; i < nrOfFriends; i++)
        {
            MyFriends.Add(new Friend().Seed(rnd));
        }
    }

    public List<string> Emails(string name)
    {
        var emails = new List<string>();
        foreach (var friend in MyFriends)
        {
            var f = _emailOptions[name];
            emails.Add(f(friend));
        }
        return emails;
    }

}
