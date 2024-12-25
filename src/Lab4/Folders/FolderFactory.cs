namespace Itmo.ObjectOrientedProgramming.Lab4.Folders;

public class FolderFactory : IFolderFactory
{
    public Folder CreateFolder(string name)
    {
        return new Folder(name);
    }
}