using Itmo.ObjectOrientedProgramming.Lab2.Labs;
using Itmo.ObjectOrientedProgramming.Lab2.Lectures;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects;

public class Subject
{
    public Subject()
    {
        Name = string.Empty;
        Description = string.Empty;
        EvaluationCriteria = string.Empty;
        Author = new User();
        ID = Guid.NewGuid();
        Lectures = new Collection<Lecture>();
        Labs = new Collection<Lab>();
    }

    public Subject(string name, string description, string evaluationCriteria, User author, bool isExam)
    {
        Name = name;
        ID = Guid.NewGuid();
        Description = description;
        EvaluationCriteria = evaluationCriteria;
        Author = author;
        Lectures = new Collection<Lecture>();
        Labs = new Collection<Lab>();
        IsExam = isExam;
    }

    public Guid ID { get; private set; }

    public Guid? ParentID { get; private set; }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public string EvaluationCriteria { get; private set; }

    public int Points { get; private set; }

    public bool IsExam { get; private set; }

    public User? Author { get; private set; }

    public Collection<Lecture> Lectures { get; private set; }

    public Collection<Lab> Labs { get; private set; }

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

    private int _sumPoints;

    public bool CheckPoints()
    {
        foreach (Lab variable in Labs)
        {
            _sumPoints += Points;
        }

        if (_sumPoints == 100)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SetExam(bool isExam)
    {
        IsExam = isExam;
    }

    public void AddLab(Lab lab)
    {
        Labs.Add(lab);
    }
}
