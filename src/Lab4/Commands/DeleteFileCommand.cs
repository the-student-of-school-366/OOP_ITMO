using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class DeleteFileCommand : ICommand
{
    private readonly FileSystem _fileSystem;
    private readonly string _path;

    public DeleteFileCommand(FileSystem fileSystem, string path)
    {
        _fileSystem = fileSystem;
        _path = path;
    }

    public void Execute()
    {
        _fileSystem.Delete(_path);
    }
}
