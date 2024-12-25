using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.ChainOfResponsibility;

public class ShowFileHandler : AbstractHandler
{
    private readonly FileSystem _fileSystem;

    public ShowFileHandler(FileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public override void Handle(string command, string[] args)
    {
        if (command == "file" && args[0] == "show")
        {
            string sourcePath = args[1];
            string mode = args[2];
            var com = new ShowFileCommand(_fileSystem, sourcePath);
            com.Execute();
        }
        else
        {
            base.Handle(command, args);
        }
    }
}