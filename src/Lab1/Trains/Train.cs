namespace Itmo.ObjectOrientedProgramming.Lab1.Trains;

public class Train
{
    public static double Accuracy => 1.2;

    private static int DefaultWeight => 445 * 1000;

    public Train(int weight, int maxAllowedPower)
    {
        Weight = weight;
        MaxAllowedPower = maxAllowedPower;
    }

    public Train() : this(DefaultWeight, 30000 * 1000) { }

    public int Weight { get; }

    public double Speed { get; private set; }

    public int Boost { get; private set; }

    public int MaxAllowedPower { get; }

    public void AddSpeed()
    {
        Speed += Boost * Accuracy;
    }

    public bool GetResultBoost(int power)
    {
        return power <= MaxAllowedPower;
    }

    public void AddBoost(int power)
    {
        if (GetResultBoost(power))
        {
            Boost += power / Weight;
            AddSpeed();
        }
    }
}