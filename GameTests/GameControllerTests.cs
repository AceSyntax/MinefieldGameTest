namespace GameTests;

using Moq;
using Xunit;
using GameBehaviour;
using GameInterfaces;


public class GameControllerTests
{


    [Fact]
    public void GameController_ShouldCallGameStarted_OnRun()
    {
        // Arrange
        var mockNavigator = new Mock<INavigator>();
        var mockGameStateTracker = new Mock<IGameStateTracker>();
        var mockPlayerFeedbackProvider = new Mock<IPlayerFeedbackProvider>();

        IGameController gameController = new GameController(mockNavigator.Object, mockGameStateTracker.Object, mockPlayerFeedbackProvider.Object, () => ConsoleKey.Enter);

        // Set up console input
        var input = new System.IO.StringReader("Enter");
        Console.SetIn(input);

        // Act
        gameController.Run();

        // Assert
        mockPlayerFeedbackProvider.Verify(m => m.GameStarted(), Times.Once);
    }

    [Fact]
    public void GameController_ShouldCallGameLost_WhenGameLost()
    {
        // Arrange
        var mockNavigator = new Mock<INavigator>();
        var mockGameStateTracker = new Mock<IGameStateTracker>();
        var mockPlayerFeedbackProvider = new Mock<IPlayerFeedbackProvider>();
        IGameController gameController = new GameController(mockNavigator.Object, mockGameStateTracker.Object, mockPlayerFeedbackProvider.Object, () => ConsoleKey.Enter);


        // Set up console input
        var input = new System.IO.StringReader("Enter");
        Console.SetIn(input);

        // Raise GameLost event
        mockGameStateTracker.Raise(m => m.GameLost += null);

        // Act
        gameController.Run();

        // Assert
        mockPlayerFeedbackProvider.Verify(m => m.GameLost(), Times.Once);
    }

    [Fact]
    public void GameController_ShouldCallGameWon_WhenGameWon()
    {
        // Arrange
        var mockNavigator = new Mock<INavigator>();
        var mockGameStateTracker = new Mock<IGameStateTracker>();
        var mockPlayerFeedbackProvider = new Mock<IPlayerFeedbackProvider>();

        IGameController gameController = new GameController(mockNavigator.Object, mockGameStateTracker.Object, mockPlayerFeedbackProvider.Object, () => ConsoleKey.Enter);


        // Set up console input
        var input = new System.IO.StringReader("Enter");
        Console.SetIn(input);

        // Raise GameWon event
        mockGameStateTracker.Raise(m => m.GameWon += null);

        // Act
        gameController.Run();

        // Assert
        mockPlayerFeedbackProvider.Verify(m => m.GameWon(), Times.Once);
    }
}

