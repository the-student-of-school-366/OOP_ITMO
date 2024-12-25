using Itmo.ObjectOrientedProgramming.Lab4.ComposerInterface;

namespace Itmo.ObjectOrientedProgramming.Lab4.Files;

public class Filee : IFile, IFileSystemComponent
{
    public Filee(string name, string content)
    {
        Name = name;
        Content = content;
    }

    public Filee()
    {
        Content = string.Empty;
        Name = string.Empty;
    }

    public string Name { get; private set; }

    public string Content { get; private set; }

    public void SetName(string name)
    {
        Name = name;
    }

    public void Rename(string newName)
    {
        Name = newName;
    }

    public void Display(string indent = "")
    {
        Console.WriteLine($"{indent}- {Name} (File)");
    }

    public void DisplayTree(int depth, int count)
    {
        string indent = string.Empty;
        Console.WriteLine($"{indent}- {Name} (File)");
    }
}