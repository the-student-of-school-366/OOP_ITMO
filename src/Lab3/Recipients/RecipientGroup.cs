using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients;

public class RecipientGroup : IEmail
{
    private readonly List<IEmail> _recipients = new();

    public void AddRecipient(IEmail recipient)
    {
        _recipients.Add(recipient);
    }

    public void SendEmail(Message message)
    {
        foreach (IEmail recipient in _recipients)
        {
            recipient.SendEmail(message);
        }
    }
}