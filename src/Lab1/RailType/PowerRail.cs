using Itmo.ObjectOrientedProgramming.Lab1.Trains;

namespace Itmo.ObjectOrientedProgramming.Lab1.RailType;

public class PowerRail : Rail
{
    public PowerRail()
    {
        _train = new Train();
    }

    public PowerRail(int lenght, int power)
    {
        Length = lenght;
        Power = power;
        RemainingLength = lenght;
        _train = new Train();
    }

    public int Power { get; }

    private Train _train;

    public override bool WayCompleted(Train train)
    {
        _train = train;
        _train.AddBoost(Power);

        if (GetWay(_train) < 0 || !_train.GetResultBoost(Power) || _train.Speed <= 0)
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