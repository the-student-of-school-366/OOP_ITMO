using Itmo.ObjectOrientedProgramming.Lab1.Trains;

namespace Itmo.ObjectOrientedProgramming.Lab1.RailType;

public class Station : Rail
{
    public Station()
    {
        _train = new Train();
    }

    public Station(int stationOccupancy, int speedLimit)
    {
        _train = new Train();

        StationOccupancy = stationOccupancy;

        SpeedLimit = speedLimit;
    }

    private Train _train;

    private int StationOccupancy { get; }

    private int SpeedLimit { get; }

    public override bool WayCompleted(Train train)
    {
        _train = train;

        if (SpeedLimit < _train.Speed)
        {
            return false;
        }

        while (RemainingLength > 0)
        {
            if (StationOccupancy is > 10 and < 100)
            {
                RemainingLength -= GetWay(_train);
            }
            else if (StationOccupancy >= 100)
            {
                RemainingLength -= GetWay(_train) * 0.5;
            }
            else
            {
                RemainingLength -= GetWay(_train) * 1.5;
            }
        }

        return true;
    }
}