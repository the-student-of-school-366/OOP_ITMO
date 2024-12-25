using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class CopyFileCommand : ICommand
{
    private readonly FileSystem _fileSystem;
    private readonly string _sourcePath;
    private readonly string _destinationPath;

    public CopyFileCommand(FileSystem fileSystem, string sourcePath, string destinationPath)
    {
        _fileSystem = fileSystem;
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public void Execute()
    {
        _fileSystem.Copy(_sourcePath, _destinationPath);
        Console.WriteLine($"Copied file from {_sourcePath} to {_destinationPath}");
    }
}