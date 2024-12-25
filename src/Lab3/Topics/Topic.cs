using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics;

public class Topic
{
    public string Name { get; private set; }

    private readonly List<IEmail> _recipients;

    public Topic(string name)
    {
        Name = name;
        _recipients = new List<IEmail>();
    }

    public void AddRecipient(IEmail recipient) => _recipients.Add(recipient);

    public void SendMessage(Message message)
    {
        foreach (IEmail recipient in _recipients)
        {
            recipient.SendEmail(message);
        }
    }

    public void SetName(string name)
    {
        Name = name;
    }
}