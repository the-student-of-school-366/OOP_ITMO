using Itmo.ObjectOrientedProgramming.Lab4.Files;
using Itmo.ObjectOrientedProgramming.Lab4.Folders;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

public class FileSystem
{
    private Folder? rootFolder;

    public Folder? CurrentFolder { get; private set; }

    public FileSystem()
    {
        rootFolder = new Folder("root");
        CurrentFolder = rootFolder;
    }

    public void Display()
    {
        CurrentFolder?.Display();
    }

    public void DisplayTree(int depth)
    {
        CurrentFolder?.DisplayTree(depth, 0);
    }

    public FileSystem(Folder currentFolder, Folder rootFolder)
    {
        this.rootFolder = rootFolder;
        CurrentFolder = currentFolder;
    }

    public void PrintInfo()
    {
        CurrentFolder?.Display();
    }

    public void Connect(string rootName)
    {
        rootFolder = new Folder(rootName);
        CurrentFolder = rootFolder;
    }

    public void Disconnect()
    {
        rootFolder = null;
        CurrentFolder = null;
    }

    public void CreateFile(string path, string content)
    {
        (Folder? parentFolder, string fileName) = NavigateToParentFolderAndName(path);
        var newFile = new Filee(fileName, content);
        parentFolder?.AddChild(newFile);
    }

    public void SetCurrentFolder(Folder folder)
    {
        CurrentFolder = folder;
    }

    public IFolder? GetFolder(string path)
    {
        return NavigateToFolder(path);
    }

    public IFile? GetFile(string path)
    {
        (Folder? parentFolder, string fileName) = NavigateToParentFolderAndName(path);

        Filee? file = parentFolder?.GetFiles().FirstOrDefault(f => f.Name == fileName);

        return file;
    }

    public void CreateFolder(string path)
    {
        (Folder? parentFolder, string folderName) = NavigateToParentFolderAndName(path);
        var newFolder = new Folder(folderName);
        parentFolder?.AddChild(newFolder);
    }

    public void Move(string source, string destination)
    {
        (Folder? sourceParent, string sourceName) = NavigateToParentFolderAndName(source);
        (Folder? destinationParent, string destinationName) = NavigateToParentFolderAndName(destination);

        ComposerInterface.IFileSystemComponent? component = sourceParent?.GetChild(sourceName);
        if (component != null)
        {
            sourceParent?.RemoveChild(component);
            component.Rename(destinationName);
            destinationParent?.AddChild(component);
        }
    }

    public void Copy(string source, string destination)
    {
        (Folder? sourceParent, string sourceName) = NavigateToParentFolderAndName(source);
        (Folder? destinationParent, string destinationName) = NavigateToParentFolderAndName(destination);

        ComposerInterface.IFileSystemComponent? component = sourceParent?.GetChild(sourceName);
        if (component is Filee file)
        {
            destinationParent?.AddChild(new Filee(destinationName, file.Content));
        }
        else if (component is Folder folder)
        {
            destinationParent?.AddChild(folder.Clone(destinationName));
        }
    }

    public void Delete(string path)
    {
        (Folder? parentFolder, string name) = NavigateToParentFolderAndName(path);
        ComposerInterface.IFileSystemComponent? component = parentFolder?.GetChild(name);
        if (component != null)
        {
            parentFolder?.RemoveChild(component);
            this.Disconnect();
        }
    }

    public void Rename(string path, string newName)
    {
        (Folder? parentFolder, string name) = NavigateToParentFolderAndName(path);
        ComposerInterface.IFileSystemComponent? component = parentFolder?.GetChild(name);
        component?.Rename(newName);
    }

    public Folder? NavigateToFolder(string path)
    {
        string[] segments = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
        Folder? current = rootFolder;

        foreach (string segment in segments)
        {
            current = current?.GetChild(segment) as Folder;
        }

        return current;
    }

    private (Folder? ParentFolder, string Name) NavigateToParentFolderAndName(string path)
    {
        string[] segments = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
        string name = segments.Last();
        string parentPath = string.Join("/", segments.Take(segments.Length - 1));
        Folder? parentFolder = string.IsNullOrEmpty(parentPath) ? rootFolder : NavigateToFolder(parentPath);

        return (parentFolder, name);
    }
}