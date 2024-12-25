using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.ChainOfResponsibility;

public class TreeListHandler : AbstractHandler
{
    private readonly FileSystem _fileSystem;

    public TreeListHandler(FileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public override void Handle(string command, string[] args)
    {
        if (command == "tree list" && args.Length == 1 && args[0].StartsWith("-d"))
        {
            if (int.TryParse(args[0].Substring(2), out int depth))
            {
                new TreeListCommand(_fileSystem, depth).Execute();
                Console.WriteLine("tree list executed");
            }
        }
        else
        {
            base.Handle(command, args);
        }
    }
}
