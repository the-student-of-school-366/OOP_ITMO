using Itmo.ObjectOrientedProgramming.Lab1.RailType;
using Itmo.ObjectOrientedProgramming.Lab1.Trains;
using Xunit;

namespace Lab1.Tests;

public class TestClass
{
    [Fact]
    public void Test_PowerRailAllowed_Rail()
    {
        var route = new Route();
        var sapsan = new Train(1000, 5000 * 1000);
        var powerRail = new PowerRail(1000, 100 * 1000);
        var rail = new Rail(48001);
        route.AddObject(powerRail);
        route.AddObject(rail);
        Assert.True(route.CheckAllRails(sapsan));
    }

    [Fact]
    public void Test_PowerRailMoreAllowedSpeed_Rail()
    {
        var route = new Route();
        var sapsan = new Train(1000, 5000 * 1000);
        var powerRail = new PowerRail(1000, 6000 * 1000);
        var rail = new Rail(48000);
        route.AddObject(powerRail);
        route.AddObject(rail);
        Assert.False(route.CheckAllRails(sapsan));
    }

    [Fact]
    public void Test_PowerRailAllowedSpeedForRouteAndStation()
    {
        var route = new Route();
        var sapsan = new Train(1000, 5000 * 1000);
        var powerRail = new PowerRail(1000, 500 * 1000);
        var rail = new Rail(48000);
        var rail2 = new Rail(36000);
        var station = new Station(5, 1000);
        route.AddObject(powerRail);
        route.AddObject(rail);
        route.AddObject(station);
        route.AddObject(rail2);
        Assert.True(route.CheckAllRails(sapsan));
    }

    [Fact]
    public void Test_PowerRailMoreAllowedSpeedForStation()
    {
        var route = new Route();
        var sapsan = new Train(1000, 5000 * 1000);
        var powerRail = new PowerRail(1000, 900 * 1000);
        var rail = new Rail(48000);
        var station = new Station(5, 1000);
        route.AddObject(powerRail);
        route.AddObject(station);
        route.AddObject(rail);
        Assert.False(route.CheckAllRails(sapsan));
    }

    [Fact]
    public void Test_PowerRailMoreAllowedSpeedrouteButLessStation()
    {
        var route = new Route();
        var sapsan = new Train(1000, 5000 * 1000);
        var powerRail = new PowerRail(1000, 900 * 1000);
        var rail = new Rail(48000);
        var rail2 = new Rail(36000);
        var station = new Station(5, 1000);
        route.AddObject(powerRail);
        route.AddObject(rail);
        route.AddObject(station);
        route.AddObject(rail2);
        route.SetMsxSpeed(500);
        Assert.False(route.CheckAllRails(sapsan));
    }

    [Fact]
    public void Test_PowerRail_Rail_PowerRail_Station_Rail_PowerRail_Rail_PowerRail()
    {
        var route = new Route();
        var sapsan = new Train(1000, 5000 * 1000);
        var powerRail = new PowerRail(1000, 500 * 1000);
        var powerRail2 = new PowerRail(1000, -400 * 1000);
        var powerRail3 = new PowerRail(1000,   1100 * 1000);
        var powerRail4 = new PowerRail(1000, -600 * 1000);
        var rail = new Rail(48000);
        var rail2 = new Rail(36000);
        var rail3 = new Rail(52000);
        var station = new Station(5, 1000);
        route.AddObject(powerRail);
        route.AddObject(rail);
        route.AddObject(powerRail2);
        route.AddObject(station);
        route.AddObject(rail2);
        route.AddObject(powerRail3);
        route.AddObject(rail3);
        route.AddObject(powerRail4);
        route.SetMsxSpeed(30000);
        Assert.True(route.CheckAllRails(sapsan));
    }

    [Fact]
    public void Test_Rail()
    {
        var route = new Route();
        var sapsan = new Train(1000, 5000 * 1000);
        var rail = new Rail(48000);
        route.AddObject(rail);
        Assert.False(route.CheckAllRails(sapsan));
    }

    [Fact]
    public void Test_PowerRail_PowerRail()
    {
        var route = new Route();
        var sapsan = new Train(1000, 5000 * 1000);
        var powerRail = new PowerRail(1000, 900 * 1000);
        var powerRail2 = new PowerRail(1000, -1800 * 1000);
        route.AddObject(powerRail);
        route.AddObject(powerRail2);
        Assert.False(route.CheckAllRails(sapsan));
    }
}