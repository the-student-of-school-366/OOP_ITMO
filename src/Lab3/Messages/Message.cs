namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public class Message
{
    public Message()
    {
        Text = string.Empty;
    }

    public Message(string header, string body, int importanceLevel)
    {
        Header = header;

        Body = body;

        Importance = importanceLevel;

        Text = header + body;
    }

    public string? Header { get; private set; }

    public string? Body { get; private set; }

    public string Text { get; private set; }

    public int Importance { get; private set; }

    public void SetImportance(int importance)
    {
        Importance = importance;
    }

    public bool IsRead { get; private set; }

    public void MarkAsRead()
    {
        IsRead = true;
    }
}