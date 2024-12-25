using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public class User : IEmail
{
    private readonly List<Message> _messages = new List<Message>();

    private readonly List<bool> _isRead = new List<bool>();

    public string Name { get; private set; }

    public User(string name)
    {
        Name = name;
    }

    public void SendEmail(Message message)
    {
        if (!_messages.Contains(message))
        {
            _messages.Add(message);
        }

        _isRead.Add(false);

        Console.WriteLine($"User {Name} received message: {message.Header}");
    }

    public bool MarkMessageAsRead(Message message)
    {
        if (!_isRead[_messages.IndexOf(message)])
        {
            _isRead[_messages.IndexOf(message)] = true;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsMessageRead(Message message)
    {
        return _isRead[_messages.IndexOf(message)];
    }
}