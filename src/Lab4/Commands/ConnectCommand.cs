using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class ConnectCommand : ICommand
{
    private readonly FileSystem _fileSystem;
    private readonly string _address;

    public ConnectCommand(FileSystem fileSystem, string address)
    {
        _fileSystem = fileSystem;
        _address = address;
    }

    public void Execute()
    {
        _fileSystem.Connect(_address);
    }
}