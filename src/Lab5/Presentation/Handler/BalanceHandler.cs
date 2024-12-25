using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Handler;

public class BalanceHandler : AbstractHandler
{
    public override void Handle(string request, User user, UserService service)
    {
        if (request == "balance")
        {
            Console.WriteLine($"Balance: {service.GetBalance(user)}");
        }
        else
        {
            Next?.Handle(request, user, service);
        }
    }
}