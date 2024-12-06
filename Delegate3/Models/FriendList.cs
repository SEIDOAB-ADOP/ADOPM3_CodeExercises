using Seido.Utilities.SeedGenerator;

namespace Delegate3;

public class FriendList
{
    public  List<Friend> MyFriends = new List<Friend>();

    private Func<Friend, string> _emailOptions = null;

    public FriendList ConfigureEmail (Func<Friend, string> options)
    {
        _emailOptions = options;
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

    public List<string> Emails()
    {
        var emails = new List<string>();
        foreach (var friend in MyFriends)
        {
            emails.Add(_emailOptions(friend));
        }
        return emails;
    }

}
