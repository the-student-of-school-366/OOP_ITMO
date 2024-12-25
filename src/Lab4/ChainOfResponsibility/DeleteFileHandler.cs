using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.ChainOfResponsibility;

public class DeleteFileHandler : AbstractHandler
{
    private readonly FileSystem _fileSystem;

    public DeleteFileHandler(FileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public override void Handle(string command, string[] args)
    {
        if (command == "file" && args[0] == "delete")
        {
            new DeleteFileCommand(_fileSystem, args[1]).Execute();
        }
        else
        {
            base.Handle(command, args);
        }
    }
}