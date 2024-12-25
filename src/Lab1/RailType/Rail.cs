using Itmo.ObjectOrientedProgramming.Lab1.Trains;

namespace Itmo.ObjectOrientedProgramming.Lab1.RailType;

public class Rail
{
    public Rail()
    {
        _train = new Train();
    }

    public Rail(int lenght)
    {
        Length = lenght;
        RemainingLength = lenght;
        _train = new Train();
    }

    public int Length { get; protected set; }

    public double RemainingLength { get; protected set; }

    private Train _train;

    public double GetWay(Train train)
    {
        _train = train;
        return _train.Speed * Train.Accuracy;
    }

    public virtual bool WayCompleted(Train train)
    {
        _train = train;
        if (GetWay(_train) <= 0)
        {
            return false;
        }

        while (RemainingLength > 0)
        {
            RemainingLength -= GetWay(_train);
        }

        return true;
    }
}