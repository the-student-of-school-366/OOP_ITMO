using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.ChainOfResponsibility;

public class CopyFileHandler : AbstractHandler
{
    private readonly FileSystem _fileSystem;

    public CopyFileHandler(FileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public override void Handle(string command, string[] args)
    {
        if (command == "file" && args[0] == "copy")
        {
            string sourcePath = args[1];
            string destinationPath = args[2];

            _fileSystem.Copy(sourcePath, destinationPath);
            Console.WriteLine($"Copied file from {sourcePath} to {destinationPath}");
            return;
        }
        else
        {
            base.Handle(command, args);
        }
    }
}
