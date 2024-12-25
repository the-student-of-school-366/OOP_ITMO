using Itmo.ObjectOrientedProgramming.Lab2.Labs;
using Itmo.ObjectOrientedProgramming.Lab2.Subjects;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

using Xunit;

namespace Lab2.Tests;

public class EducationProgramTest
{
    [Fact]
    public void TestUnauthorizedEdit_ShouldThrowException()
    {
        var author = new User("Author");
        var anotherUser = new User("AnotherUser");

        var lab = new Lab("Lab 1", "Description", 20, author);
        string description = "Description";

        Assert.False(lab.UpdateDescription(description, anotherUser));
    }

    [Fact]
    public void TestCloneLabWork_ShouldContainBaseLabId()
    {
        var author = new User("Author");
        var originalLab = new Lab("Lab 1", "Description", 20, author);
        var clonedLab = new Lab();
        clonedLab.Clone(originalLab);

        Assert.Equal(originalLab.ID, clonedLab.ParentID);
    }

    [Fact]
    public void TestSubjectContainNot100Points()
    {
        var subject = new Subject();

        var lab1 = new Lab();

        lab1.SetPoints(30);

        var lab2 = new Lab();

        lab2.SetPoints(40);

        subject.AddLab(lab1);

        subject.AddLab(lab2);

        Assert.False(subject.CheckPoints());
    }
}
