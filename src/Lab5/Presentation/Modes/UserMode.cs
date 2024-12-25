using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Handler;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Modes;

public class UserMode
{
    public void Handle(UserService service)
    {
        Console.Write("Enter account number: ");
        string? input = Console.ReadLine();
        if (input is not null)
        {
            int userNumber = int.Parse(input);

            Console.Write("Enter PIN: ");
            string? pin = Console.ReadLine();

            try
            {
                if (pin != null)
                {
                    User? account = service.GetUser(userNumber, pin);
                    var balanceHandler = new BalanceHandler();
                    var withdrawHandler = new WithdrawHandler();
                    var depositHandler = new DepositHandler();
                    var historyHandler = new HistoryHandler();

                    balanceHandler.SetNext(withdrawHandler);
                    withdrawHandler.SetNext(depositHandler);
                    depositHandler.SetNext(historyHandler);

                    while (true)
                    {
                        Console.WriteLine("1 - View Balance, 2 - Withdraw, 3 - Deposit, 4 - Transaction History, 0 - Exit");
                        string? option = Console.ReadLine();

                        if (option == "0") break;

                        if (option != null)
                        {
                            if (account != null)
                                balanceHandler.Handle(option, account, service);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}