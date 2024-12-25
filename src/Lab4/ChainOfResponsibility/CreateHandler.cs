using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.ChainOfResponsibility;

public class CreateHandler : AbstractHandler
{
    private readonly FileSystem _fileSystem;

    public CreateHandler(FileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public override void Handle(string command, string[] args)
    {
        if (command == "create")
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: create <path> <content>");
                return;
            }

            string path = args[0];
            string content = args[1];
            _fileSystem.CreateFile(path, content);
            Console.WriteLine($"File created at {path}");
        }
        else
        {
            base.Handle(command, args);
        }
    }
}