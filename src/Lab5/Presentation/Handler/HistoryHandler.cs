using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Handler;

public class HistoryHandler : AbstractHandler
{
    public override void Handle(string request, User user, UserService service)
    {
        if (request == "history")
        {
            Console.WriteLine("Transaction History:");
            foreach (string transaction in service.GetHistory(user))
            {
                Console.WriteLine(transaction);
            }
        }
        else
        {
            Next?.Handle(request, user, service);
        }
    }
}