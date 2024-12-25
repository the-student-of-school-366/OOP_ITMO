using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Filters;

public class FilteredRecipient : IEmail
{
    private readonly IEmail _recipient;
    private readonly IMessageFilter _filter;

    public FilteredRecipient(IEmail recipient, IMessageFilter filter)
    {
        _recipient = recipient;
        _filter = filter;
    }

    public void SendEmail(Message message)
    {
        if (_filter.ShouldDeliverMessage(message))
        {
            _recipient.SendEmail(message);
        }
    }
}