using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public abstract class CommandBase
{
    protected FileSystem FileSystem { get; private set; }

    protected CommandBase(FileSystem fileSystem)
    {
        FileSystem = fileSystem;
    }

    public abstract void Execute();
}