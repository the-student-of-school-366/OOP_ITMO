using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Handler;

public class DepositHandler : AbstractHandler
{
    public override void Handle(string request, User user, UserService service)
    {
        if (request == "deposit")
        {
            Console.Write("Enter amount to deposit: ");
            string? input = Console.ReadLine();
            if (input is not null)
            {
                decimal amount = decimal.Parse(input);
                service.Deposit(user, amount);
                Console.WriteLine("Deposit successful.");
            }
        }
        else
        {
            Next?.Handle(request, user, service);
        }
    }
}