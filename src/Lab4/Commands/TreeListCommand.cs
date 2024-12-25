using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeListCommand : ICommand
{
    private readonly FileSystem _fileSystem;
    private readonly int _depth;

    public TreeListCommand(FileSystem fileSystem, int depth)
    {
        _fileSystem = fileSystem;
        _depth = depth;
    }

    public void Execute()
    {
        _fileSystem.DisplayTree(_depth);
    }
}