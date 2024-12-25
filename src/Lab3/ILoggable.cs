using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public interface ILoggable : IEmail
{
    void LogMessage(Message message);
}