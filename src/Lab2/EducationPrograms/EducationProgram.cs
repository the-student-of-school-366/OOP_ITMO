using Itmo.ObjectOrientedProgramming.Lab2.Subjects;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationPrograms;

public class EducationProgram
{
    public EducationProgram() { }

    public EducationProgram(string name, string boss)
    {
        ID = Guid.NewGuid();
        Name = name;
        Boss = boss;
        Subjects = new Collection<Subject>();
        SubjectsBySemestr = new Dictionary<int, List<Subject>>();
    }

    public Guid ID { get; private set; }

    public string? Name { get; private set; }

    public Collection<Subject>? Subjects { get; private set; }

    public Dictionary<int, List<Subject>>? SubjectsBySemestr { get; private set; }

    public string? Boss { get; private set; }
}