using Itmo.ObjectOrientedProgramming.Lab5.Application.Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts;

public interface IUserRepository
{
    User? GetUserByID(int id);

    void SaveUser(User user);
}