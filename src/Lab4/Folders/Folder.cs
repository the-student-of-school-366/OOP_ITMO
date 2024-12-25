using Itmo.ObjectOrientedProgramming.Lab4.ComposerInterface;
using Itmo.ObjectOrientedProgramming.Lab4.Files;

namespace Itmo.ObjectOrientedProgramming.Lab4.Folders;

public class Folder : IFolder, IFileSystemComponent
{
    public string Name { get; set; }

    private readonly List<IFileSystemComponent> _children = new();

    public IEnumerable<IFileSystemComponent> Children => _children;

    private int _count;

    public Folder(string name)
    {
        Name = name;
    }

    public Folder()
    {
        Name = string.Empty;
    }

    public void AddChild(IFileSystemComponent component)
    {
        _children.Add(component);
    }

    public void RemoveChild(IFileSystemComponent component)
    {
        _children.Remove(component);
    }

    public IFileSystemComponent? GetChild(string name)
    {
        return _children.FirstOrDefault(c => c.Name == name);
    }

    public void Rename(string newName)
    {
        Name = newName;
    }

    public void Display(string indent = "")
    {
        Console.WriteLine($"{indent}+ {Name} (Folder)");
        foreach (IFileSystemComponent child in _children)
        {
            child.Display(indent + "  ");
        }
    }

    public void DisplayTree(int depth, int count)
    {
        string indent = string.Empty;
        _count = count + 1;
        Console.WriteLine($"{indent}+ {Name} (Folder)");
        foreach (IFileSystemComponent child in _children)
        {
            if (_count == depth)
            {
                break;
            }

            child.DisplayTree(depth, _count);
        }
    }

    public Folder Clone(string newName)
    {
        var clone = new Folder(newName);

        foreach (IFileSystemComponent child in _children)
        {
            if (child is Folder folder)
            {
                clone.AddChild(folder.Clone(folder.Name));
            }
            else if (child is Filee file)
            {
                clone.AddChild(new Filee(file.Name, file.Content));
            }
        }

        return clone;
    }

    public IEnumerable<Folder> GetSubfolders()
    {
        return _children.OfType<Folder>();
    }

    public IEnumerable<Filee> GetFiles()
    {
        return _children.OfType<Filee>();
    }
}