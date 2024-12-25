using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public interface IMessageFilter
{
    bool ShouldDeliverMessage(Message message);
}