using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects;

public class SubjectBuilder
{
    public Guid ID { get; private set; }

    public User? Author { get; private set; }

    public string? Name { get; private set; }

    public int Points { get; private set; }

    public void SetId(Guid id)
    {
        ID = id;
    }

    public void SetAuthor(User? author)
    {
        Author = author;
    }

    public void SetName(string name)
    {
        Name = name;
    }

    public bool SetPoints(int points)
    {
        if (points <= 0)
        {
            return false;
        }

        if (points > 100)
        {
            return false;
        }

        Points = points;
        return true;
    }

    public Subject Build()
    {
        return new Subject();
    }
}