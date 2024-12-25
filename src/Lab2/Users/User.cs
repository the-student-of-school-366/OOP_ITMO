namespace Itmo.ObjectOrientedProgramming.Lab2.Users;

public class User
{
    public User()
    {
        Name = string.Empty;
    }

    public User(string name)
    {
        ID = Guid.NewGuid();

        Name = name;
    }

    public void Nothing()
    {
        Name = string.Empty;
    }

    public Guid ID { get; private set; }

    public string Name { get; private set; }
}