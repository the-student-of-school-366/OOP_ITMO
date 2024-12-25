using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class Display : IEmail
{
    private string? _lastMessage;

    public void SendEmail(Message message)
    {
        _lastMessage = null;
        _lastMessage = message.Text;
        Console.WriteLine($"Display shows message: {_lastMessage}");
    }
}