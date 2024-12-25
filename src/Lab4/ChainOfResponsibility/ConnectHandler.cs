using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.ChainOfResponsibility;

public class ConnectHandler : AbstractHandler
{
    private readonly FileSystem _fileSystem;

    public ConnectHandler(FileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public override void Handle(string command, string[] args)
    {
        if (command == "connect")
        {
            new ConnectCommand(_fileSystem, args[0]).Execute();
            Console.WriteLine("Connected to " + args[0]);
        }
        else
        {
            base.Handle(command, args);
        }
    }
}
