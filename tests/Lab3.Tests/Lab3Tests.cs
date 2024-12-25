using Itmo.ObjectOrientedProgramming.Lab3;
using Itmo.ObjectOrientedProgramming.Lab3.Filters;
using Itmo.ObjectOrientedProgramming.Lab3.Loges;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients;
using Itmo.ObjectOrientedProgramming.Lab3.Users;
using Moq;
using Xunit;
using Message = Itmo.ObjectOrientedProgramming.Lab3.Messages.Message;

namespace Lab3.Tests;

public class Lab3Tests
{
    // 1
    [Fact]
    public void UserReceivesMessage_NotReadByDefault()
    {
        var user = new User("Test User");
        var message = new Message("Test Header", "Test Body", 2);

        user.SendEmail(message);
        Assert.False(user.IsMessageRead(message));
    }

    // 2
    [Fact]
    public void MarkUnreadMessageAsRead_ChangesStatusToRead()
    {
        var user = new User("Test User");
        var message = new Message("Test Header", "Test Body", 2);
        user.SendEmail(message);

        user.MarkMessageAsRead(message);

        Assert.True(user.IsMessageRead(message));
    }

    // 3
    [Fact]
    public void MarkReadMessageAsRead_ThrowsException()
    {
        var user = new User("Test User");
        var message = new Message("Test Header", "Test Body", 2);
        user.SendEmail(message);
        user.MarkMessageAsRead(message);

        Assert.False(user.MarkMessageAsRead(message));
    }

    // 4
    [Fact]
    public void FilteredRecipient_DoesNotReceiveLowImportanceMessage()
    {
        var mockRecipient = new Mock<IEmail>();
        var filter = new ImportanceFilter(3);
        var filteredRecipient = new FilteredRecipient(mockRecipient.Object, filter);
        var lowImportanceMessage = new Message();
        lowImportanceMessage.SetImportance(1);
        filteredRecipient.SendEmail(lowImportanceMessage);

        mockRecipient.Verify(r => r.SendEmail(It.IsAny<Message>()), Times.Never, "Recipient should not receive low-importance message.");
    }

    // 5
    [Fact]
    public void LoggedRecipient_WritesLogWhenMessageReceived()
    {
        var mockRecipient = new Mock<IEmail>();
        var loggedRecipient = new Loge(mockRecipient.Object);
        var message = new Message("Test Header", "Test Body", 2);
        loggedRecipient.SendEmail(message);
        mockRecipient.Verify(r => r.SendEmail(message), Times.Once);
    }

    // 6
    [Fact]
    public void Messenger_ReceivesMessage_CorrectOutput()
    {
        var mockMessenger = new Mock<IMessenger>();
        var message = new Message("Test Header", "Test Body", 2);

        mockMessenger.Object.SendEmail(message);

        mockMessenger.Verify(m => m.SendEmail(It.Is<Message>(msg => msg.Header == "Test Header" && msg.Body == "Test Body")), Times.Once);
    }

    // 7
    [Fact]
    public void MultipleRecipients_WithImportanceFilter_ReceivesMessageOnce()
    {
        var user1 = new Mock<IEmail>();
        var user2 = new Mock<IEmail>();
        var highImportanceFilter = new ImportanceFilter(3);
        var filteredUser1 = new FilteredRecipient(user1.Object, highImportanceFilter);
        var filteredUser2 = new FilteredRecipient(user2.Object, highImportanceFilter);

        var groupRecipient = new RecipientGroup();
        groupRecipient.AddRecipient(filteredUser1);
        groupRecipient.AddRecipient(filteredUser2);

        var lowImportanceMessage = new Message();
        lowImportanceMessage.SetImportance(1);
        var highImportanceMessage = new Message();
        highImportanceMessage.SetImportance(3);
        groupRecipient.SendEmail(lowImportanceMessage);
        groupRecipient.SendEmail(highImportanceMessage);

        user1.Verify(r => r.SendEmail(highImportanceMessage), Times.Once);
        user2.Verify(r => r.SendEmail(highImportanceMessage), Times.Once);
        user1.Verify(r => r.SendEmail(lowImportanceMessage), Times.Never);
        user2.Verify(r => r.SendEmail(lowImportanceMessage), Times.Never);
    }
}
