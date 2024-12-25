using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Handler;

public abstract class AbstractHandler
{
    public AbstractHandler? Next { get; private set; }

    public void SetNext(AbstractHandler next)
    {
        Next = next;
    }

    public abstract void Handle(string request, User user, UserService service);
}