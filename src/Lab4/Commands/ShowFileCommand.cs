using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class ShowFileCommand : ICommand
{
    private readonly FileSystem _fileSystem;
    private readonly string _path;

    public ShowFileCommand(FileSystem fileSystem, string path)
    {
        _fileSystem = fileSystem;
        _path = path;
    }

    public void Execute()
    {
        Files.IFile? file = _fileSystem.GetFile(_path);
        if (file != null)
        {
            Console.WriteLine(file.Content);
        }
    }
}
