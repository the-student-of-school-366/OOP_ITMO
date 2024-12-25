using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class CreateFileCommand : ICommand
{
    private readonly string _path;
    private readonly string _content;
    private readonly FileSystem _fileSystem;

    public CreateFileCommand(FileSystem fileSystem, string path, string content)
    {
        _path = path;
        _content = content;
        _fileSystem = fileSystem;
    }

    public void Execute()
    {
        _fileSystem.CreateFile(_path, _content);
    }
}