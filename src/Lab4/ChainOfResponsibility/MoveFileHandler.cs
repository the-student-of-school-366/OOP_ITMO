using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.ChainOfResponsibility;

public class MoveFileHandler : AbstractHandler
{
    private readonly FileSystem _fileSystem;

    public MoveFileHandler(FileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public override void Handle(string command, string[] args)
    {
        if (command == "file" && args[0] == "move")
        {
            new MoveFileCommand(_fileSystem, args[1], args[2]).Execute();
        }
        else
        {
             base.Handle(command, args);
        }
    }
}