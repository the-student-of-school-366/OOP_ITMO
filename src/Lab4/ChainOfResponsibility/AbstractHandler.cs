namespace Itmo.ObjectOrientedProgramming.Lab4.ChainOfResponsibility;

public class AbstractHandler
{
    private AbstractHandler? _nextHandler;

    public void SetNext(AbstractHandler handler)
    {
        _nextHandler = handler;
    }

    public virtual void Handle(string command, string[] args)
    {
        if (_nextHandler != null)
        {
            _nextHandler.Handle(command, args);
        }
        else
        {
            Console.WriteLine($"Command '{command}' not recognized.");
        }
    }
}