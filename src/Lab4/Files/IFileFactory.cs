namespace Itmo.ObjectOrientedProgramming.Lab4.Files;

public interface IFileFactory
{
    Filee CreateFile(string name, string content);
}