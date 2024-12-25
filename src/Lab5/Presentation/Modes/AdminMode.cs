namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Modes;

public class AdminMode
{
    public void Handle(string? adminPassword)
    {
        Console.Write("Enter admin password: ");
        string? password = Console.ReadLine();

        if (password != adminPassword)
        {
            Console.WriteLine("Incorrect password. Exiting.");
            Environment.Exit(0);
        }

        Console.WriteLine("Admin mode activated. (No additional functionality implemented yet.)");
    }
}