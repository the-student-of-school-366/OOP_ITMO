using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class MoveFileCommand : ICommand
{
    private readonly FileSystem _fileSystem;
    private readonly string _sourcePath;
    private readonly string _destinationPath;

    public MoveFileCommand(FileSystem fileSystem, string sourcePath, string destinationPath)
    {
        _fileSystem = fileSystem;
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public void Execute()
    {
        _fileSystem.Move(_sourcePath, _destinationPath);
        Console.WriteLine($"Moved file from {_sourcePath} to {_destinationPath}");
    }
}
