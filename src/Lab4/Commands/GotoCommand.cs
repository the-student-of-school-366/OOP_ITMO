using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class GotoCommand : ICommand
{
    private readonly FileSystem _fileSystem;
    private readonly string _path;

    public GotoCommand(FileSystem fileSystem, string path)
    {
        _fileSystem = fileSystem;
        _path = path;
    }

    public void Execute()
    {
        Folders.Folder? folder = _fileSystem.NavigateToFolder(_path);
        if (folder != null)
        {
            _fileSystem.SetCurrentFolder(folder);
        }
    }
}