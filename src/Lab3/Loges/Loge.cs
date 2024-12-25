using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Users;

namespace Itmo.ObjectOrientedProgramming.Lab3.Loges;

public class Loge(IEmail recipient) : ILoggable
{
    public void SendEmail(Message message)
    {
        LogMessage(message);
        recipient.SendEmail(message);
    }

    public void LogMessage(Message message)
    {
        Console.WriteLine($"[LOG] Message received by {(recipient is User user ? user.Name : "recipient")}: {message.Header}");
    }
}