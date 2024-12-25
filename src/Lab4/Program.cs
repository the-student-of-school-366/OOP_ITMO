using Itmo.ObjectOrientedProgramming.Lab4.ChainOfResponsibility;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class Program
{
    private static readonly string[] Args = new[] { "local" };
    private static readonly string[] ArgsArray = new[] { "/folder" };
    private static readonly string[] ArgsArray2 = new[] { "/GOOOOL" };
    private static readonly string[] ArgsArray3 = new[] { "/Victory" };
    private static readonly string[] ArgsArray0 = new[] { "-d2" };
    private static readonly string[] ArgsArray1 = new[] { "/folder", "Hello, world!" };

    public static void Main(string[] args)
    {
        var fileSystem = new FileSystem();

        var connectHandler = new ConnectHandler(fileSystem);
        var disconnectHandler = new DisconnectHandler(fileSystem);
        var gotoHandler = new GotoHandler(fileSystem);
        var treeListHandler = new TreeListHandler(fileSystem);
        var createHandler = new CreateHandler(fileSystem);

        connectHandler.SetNext(disconnectHandler);
        disconnectHandler.SetNext(gotoHandler);
        gotoHandler.SetNext(treeListHandler);
        treeListHandler.SetNext(createHandler);

        connectHandler.Handle("connect", Args);
        connectHandler.Handle("tree goto", ArgsArray);
        connectHandler.Handle("connect", ArgsArray2);
        connectHandler.Handle("connect", ArgsArray3);
        connectHandler.Handle("create", ArgsArray1);
        connectHandler.Handle("tree list", ArgsArray0);
        connectHandler.Handle("disconnect", Array.Empty<string>());
    }
}