using Itmo.ObjectOrientedProgramming.Lab1.Trains;

namespace Itmo.ObjectOrientedProgramming.Lab1.RailType;

public class Route
{
    public Route()
    {
        railObjects = new List<Rail>();
        MaxSpeed = 1000;
    }

    public Route(int maxSpeed)
    {
        railObjects = new List<Rail>();
        MaxSpeed = maxSpeed;
    }

    private readonly List<Rail> railObjects;

    public int MaxSpeed { get; private set; }

    public int Size { get; private set; }

    public void SetMsxSpeed(int msxSpeed)
   {
       MaxSpeed = msxSpeed;
   }

    public void AddObject(Rail rail)
   {
       railObjects.Add(rail);
       Size++;
   }

    public Rail GetObject(int index)
   {
       return railObjects[index];
   }

    public void DeleteObject(int index)
   {
       railObjects.RemoveAt(index);
       Size--;
   }

    public bool CheckSpeed(Train train)
    {
        return train.Speed <= MaxSpeed;
    }

    public bool CheckAllRails(Train train)
    {
        bool result = true;
        foreach (Rail index in railObjects)
        {
            result = result && index.WayCompleted(train);
        }

        result = result && CheckSpeed(train);
        return result;
    }
}