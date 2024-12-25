using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.ChainOfResponsibility;

public class DisconnectHandler : AbstractHandler
{
    private readonly FileSystem _fileSystem;

    public DisconnectHandler(FileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public override void Handle(string command, string[] args)
    {
        if (command == "disconnect")
        {
            new DisconnectCommand(_fileSystem).Execute();
        }
        else
        {
            base.Handle(command, args);
        }
    }
}
