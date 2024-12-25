namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Models;

public class User
{
    public User(int id, string password, decimal balance, IEnumerable<string> history)
    {
        ID = id;
        Password = password;
        Balance = balance;
        History = new List<string>(history);
    }

    public IEnumerable<string> History { get; set; }

    public IEnumerable<string> AddHistory(IEnumerable<string> source, string item)
    {
        foreach (string element in source)
        {
            yield return element;
        }

        yield return item;
    }

    public int ID { get; }

    public string? Password { get; }

    public decimal Balance { get;  set; }
}