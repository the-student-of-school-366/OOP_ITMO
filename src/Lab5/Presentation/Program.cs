using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab5.Infrastructure;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Modes;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation;

public class Program
{
    private const string AdminPassword = "admin123";

    public static void Main(string[] args)
    {
        var repository = new UserRepository("Host=localhost;Port=5432;Username=postgres;Password=docker;Database=atm_db");
        var service = new UserService(repository);

        while (true)
        {
            Console.WriteLine("Select mode: 1 - User, 2 - Admin, 0 - Exit");
            string? mode = Console.ReadLine();

            if (mode == "0") break;

            switch (mode)
            {
                case "1":
                    var student = new UserMode();
                    student.Handle(service);
                    break;
                case "2":
                    var dekan = new AdminMode();
                    dekan.Handle(AdminPassword);
                    break;
                default:
                    Console.WriteLine("Invalid selection. Try again.");
                    break;
            }
        }
    }
}