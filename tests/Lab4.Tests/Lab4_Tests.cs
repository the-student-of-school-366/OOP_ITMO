using Itmo.ObjectOrientedProgramming.Lab4.ChainOfResponsibility;
using Itmo.ObjectOrientedProgramming.Lab4.Files;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Folders;
using Xunit;

namespace Lab4.Tests;

public class Lab4_Tests
{
    [Fact]
    public void CreateFolder_CreatesNewFolderInRoot()
    {
        var fileSystem = new FileSystem();

        var connectHandler = new ConnectHandler(fileSystem);
        var disconnectHandler = new DisconnectHandler(fileSystem);
        var gotoHandler = new GotoHandler(fileSystem);
        var treeListHandler = new TreeListHandler(fileSystem);
        var fileShowHandler = new ShowFileHandler(fileSystem);
        var fileMoveHandler = new MoveFileHandler(fileSystem);
        var fileCopyHandler = new CopyFileHandler(fileSystem);

        connectHandler.SetNext(disconnectHandler);
        disconnectHandler.SetNext(gotoHandler);
        gotoHandler.SetNext(treeListHandler);
        treeListHandler.SetNext(fileShowHandler);
        fileShowHandler.SetNext(fileMoveHandler);
        fileMoveHandler.SetNext(fileCopyHandler);
        fileSystem.Connect("root");

        fileSystem.CreateFolder("/Folder1");

        IFolder? folder = fileSystem.GetFolder("/Folder1");

        Assert.NotNull(folder);
        Assert.Equal("Folder1", folder.Name);
    }

    [Fact]
    public void CreateFile_CreatesNewFileWithContent()
    {
        var fileSystem = new FileSystem();
        fileSystem.Connect("root");

        fileSystem.CreateFile("/File1.txt", "Hello, World!");

        IFile? file = fileSystem.GetFile("/File1.txt");

        Assert.NotNull(file);
        Assert.Equal("File1.txt", file?.Name);
    }

    [Fact]
    public void CopyFile_CreatesDuplicateFileInNewLocation()
    {
        var fileSystem = new FileSystem();
        fileSystem.Connect("root");

        fileSystem.CreateFile("/File1.txt", "Content");
        fileSystem.CreateFolder("/Folder1");

        fileSystem.Copy("/File1.txt", "/Folder1/File1Copy.txt");

        IFile? originalFile = fileSystem.GetFile("/File1.txt");
        IFile? copiedFile = fileSystem.GetFile("/Folder1/File1Copy.txt");

        Assert.NotNull(originalFile);
        Assert.NotNull(copiedFile);
        Assert.Equal("Content", ((Filee)originalFile).Content);
        Assert.Equal("Content", ((Filee)copiedFile).Content);
    }
}