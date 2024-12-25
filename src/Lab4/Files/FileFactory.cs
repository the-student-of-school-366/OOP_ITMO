namespace Itmo.ObjectOrientedProgramming.Lab4.Files;

public class FileFactory : IFileFactory
{
    public Filee CreateFile(string name, string content)
    {
        return new Filee(name, content);
    }
}