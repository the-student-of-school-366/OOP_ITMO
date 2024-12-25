using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions;

public class UserService
{
    private IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void SetUserRepository(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public User? GetUser(int id, string password)
    {
        User? user = _userRepository.GetUserByID(id);

        if (user is null || user.Password != password)
        {
            Console.WriteLine("Invalid password or user.");
            return null;
        }
        else
        {
            return user;
        }
    }

    public decimal GetBalance(User user)
    {
        return user.Balance;
    }

    public void Withdraw(User user, decimal amount)
    {
        if (user.Balance < amount || amount < 0)
        {
            throw new InvalidOperationException("Insufficient balance.");
        }
        else
        {
            user.Balance -= amount;
            user.History = user.AddHistory(user.History, $"Withdrawn: {amount}");
            _userRepository.SaveUser(user);
        }
    }

    public void Deposit(User user, decimal amount)
    {
        if (user.Balance < amount || amount < 0)
        {
            throw new InvalidOperationException("Insufficient balance.");
        }
        else
        {
            user.Balance += amount;
            user.History = user.AddHistory(user.History, $"Deposit: {amount}");
            _userRepository.SaveUser(user);
        }
    }

    public IEnumerable<string> GetHistory(User user)
    {
        return user.History;
    }
}