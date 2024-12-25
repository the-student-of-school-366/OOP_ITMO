using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models;
using Moq;
using System.Collections.ObjectModel;
using Xunit;

namespace Lab5.Tests;

public class Lab5Tests
{
     public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _mockRepository;
        private readonly UserService _userService;

        public UserServiceTests()
        {
            _mockRepository = new Mock<IUserRepository>();
            _userService = new UserService(_mockRepository.Object);
        }

        [Fact]
        public void Withdraw_SufficientBalance_UpdatesBalanceAndSavesUser()
        {
            var user = new User(123456, "1234", 100, new Collection<string>());

            _mockRepository.Setup(r => r.GetUserByID(123456)).Returns(user);

            _userService.Withdraw(user, 50);
            Assert.Equal(50, user.Balance);

            Assert.Contains("Withdrawn: 50", user.History);
            _mockRepository.Verify(r => r.SaveUser(user), Times.Once);
        }

        [Fact]
        public void Withdraw_InsufficientBalance_ThrowsException()
        {
            var user = new User(123456, "1234", 30, new List<string>());
            _mockRepository.Setup(r => r.GetUserByID(123456)).Returns(user);

            Assert.Throws<InvalidOperationException>(() => _userService.Withdraw(user, 50));
        }

        [Fact]
        public void Deposit_ValidAmount_UpdatesBalanceAndSavesUser()
        {
            var user = new User(123456, "1234", 100, new List<string>());
            _mockRepository.Setup(r => r.GetUserByID(123456)).Returns(user);

            _userService.Deposit(user, 50);
            Assert.Equal(150, user.Balance);

            Assert.Contains("Deposit: 50", user.History);
            _mockRepository.Verify(r => r.SaveUser(user), Times.Once);
        }
    }
}