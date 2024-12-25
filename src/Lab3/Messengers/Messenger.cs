using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers;

public class Messenger : IMessenger, IEmail
{
    public Message? Message { get; private set; }

    public void SendEmail(Message message)
    {
        Message = message;
        Console.WriteLine($"Мессенджер получил сообщение: {message.Header} - {message.Body}");
    }
}
