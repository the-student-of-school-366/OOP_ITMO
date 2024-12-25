using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Handler;

public class WithdrawHandler : AbstractHandler
{
    public override void Handle(string request, User user, UserService service)
    {
        if (request == "withdraw")
        {
            Console.Write("Enter amount to withdraw: ");
            string? input = Console.ReadLine();
            if (input is not null)
            {
                decimal amount = decimal.Parse(input);
                service.Withdraw(user, amount);
                Console.WriteLine("Withdrawal successful.");
            }
        }
        else
        {
            Next?.Handle(request, user, service);
        }
    }
}