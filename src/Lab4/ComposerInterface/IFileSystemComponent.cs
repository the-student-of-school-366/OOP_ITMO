namespace Itmo.ObjectOrientedProgramming.Lab4.ComposerInterface;

public interface IFileSystemComponent
{
    string Name { get; }

    void Rename(string newName);

    void Display(string indent = "");

    void DisplayTree(int depth, int count);
}