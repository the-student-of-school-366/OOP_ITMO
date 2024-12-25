using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Lectures;

public class Lecture
{
    public Lecture() { }

    public Lecture(string name, string description, string content, User user)
    {
        Description = description;
        Name = name;
        ID = Guid.NewGuid();
        Content = content;
        Author = new User();
    }

    public void Clone(Lecture lecture)
    {
        ParentID = lecture.ID;
        Description = lecture.Description;
        Name = lecture.Name;
        Author = new User();
        Description = lecture.Description;
        Content = lecture.Content;
    }

    public Guid? ID { get; private set; }

    public Guid? ParentID { get; private set; }

    public string? Name { get; private set; }

    public string? Description { get; private set; }

    public string? Content { get; private set; }

    public User? Author { get; private set; }

    public void UpdateDescription(string description, User user)
    {
        if (Author == user)
        {
            Description = description;
        }
        else
        {
            Console.WriteLine("User is not author!");
        }
    }
}