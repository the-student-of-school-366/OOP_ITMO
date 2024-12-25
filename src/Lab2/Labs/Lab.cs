using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Labs;

public class Lab
{
    public Lab()
    {
        Name = string.Empty;
        Description = string.Empty;
        EvaluationCriteria = string.Empty;
        Author = new User();
        ID = Guid.NewGuid();
    }

    public Lab(string name, string description, int points, User user)
    {
        Description = description;
        Name = name;
        Points = points;
        Description = description;
        Author = new User();
        ID = Guid.NewGuid();
    }

    public void Clone(Lab lab)
    {
        ParentID = lab.ID;
        Description = lab.Description;
        Name = lab.Name;
        Points = lab.Points;
        EvaluationCriteria = lab.EvaluationCriteria;
        Author = new User();
        ID = Guid.NewGuid();
    }

    public Guid ID { get; private set; }

    public Guid? ParentID { get; private set; }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public string? EvaluationCriteria { get; private set; }

    public int Points { get; private set; }

    public User? Author { get; private set; }

    public void SetPoints(int points)
    {
        Points = points;
    }

    public bool UpdateDescription(string description, User user)
    {
        if (Author == user)
        {
            Description = description;
            return true;
        }
        else
        {
            Console.WriteLine("User is not author!");
            return false;
        }
    }

    public void Blank()
    {
        Console.WriteLine("Blank");
    }
}