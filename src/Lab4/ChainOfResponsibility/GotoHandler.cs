using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.ChainOfResponsibility;

public class GotoHandler : AbstractHandler
{
    private readonly FileSystem _fileSystem;

    public GotoHandler(FileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public override void Handle(string command, string[] args)
    {
        if (command == "tree goto" && args.Length == 1)
        {
            new GotoCommand(_fileSystem, args[0]).Execute();
            Console.WriteLine($"tree goto {args[0]}");
        }
        else
        {
            base.Handle(command, args);
        }
    }
}
