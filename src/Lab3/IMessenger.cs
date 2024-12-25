using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public interface IMessenger
{
    void SendEmail(Message message);
}