using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Filters;

public class ImportanceFilter : IMessageFilter
{
    private readonly int _requiredImportance;

    public ImportanceFilter(int requiredImportance)
    {
        _requiredImportance = requiredImportance;
    }

    public bool ShouldDeliverMessage(Message message)
    {
        return message.Importance >= _requiredImportance;
    }
}