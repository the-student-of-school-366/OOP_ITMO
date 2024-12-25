namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class DisplayDriver
{
    public void Clear()
    {
        Console.ResetColor();
        Console.WriteLine("Дисплей очищен.");
    }

    public void SetGreen()
    {
        Console.ForegroundColor = ConsoleColor.Green;
    }

    public void SetBlue()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
    }

    public void SetRed()
    {
        Console.ForegroundColor = ConsoleColor.Red;
    }

    public void WriteText(string text)
    {
        Console.WriteLine(text);
    }
}