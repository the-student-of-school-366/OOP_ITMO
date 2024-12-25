using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class RenameFileCommand : ICommand
{
    private readonly FileSystem _fileSystem;
    private readonly string _path;
    private readonly string _newName;

    public RenameFileCommand(FileSystem fileSystem, string path, string newName)
    {
        _fileSystem = fileSystem;
        _path = path;
        _newName = newName;
    }

    public void Execute()
    {
        _fileSystem.Rename(_path, _newName);
    }
}