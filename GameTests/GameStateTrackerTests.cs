namespace GameTests;

using System.Collections.Generic;
using System.Linq;
using Xunit;
using GameBehaviour;
using GameInterfaces;
using GameModels;

public class GameStateTrackerTests
{
    private IMineFieldGenerator CreateFakeMineFieldGenerator()
    {
        return new FakeMineFieldGenerator();
    }

    private class FakeMineFieldGenerator : IMineFieldGenerator
    {
        public List<IMine> GenerateMines(int numberOfMines)
        {
            return new List<IMine>
            {
                new Mine(new GridLocation(2, 2)),
                new Mine(new GridLocation(4, 1)),
                new Mine(new GridLocation(3, 3)),
                new Mine(new GridLocation(1, 5)),
                new Mine(new GridLocation(5, 6))
            };
        }
    }

    [Fact]
    public void GameStateTracker_ShouldInitializeCorrectly()
    {
        // Arrange
        IMineFieldGenerator mineFieldGenerator = CreateFakeMineFieldGenerator();

        // Act
        IGameStateTracker gameStateTracker = new GameStateTracker(mineFieldGenerator);

        // Assert
        Assert.Equal(4, gameStateTracker.LivesLeft);
        Assert.Equal(1, gameStateTracker.Score);
        Assert.Equal(new GridLocation(3, 0), gameStateTracker.CurrentLocation);
    }

    [Fact]
    public void AddNewLocation_ShouldUpdateCurrentLocation()
    {
        // Arrange
        IMineFieldGenerator mineFieldGenerator = CreateFakeMineFieldGenerator();
        IGameStateTracker gameStateTracker = new GameStateTracker(mineFieldGenerator);
        IGridLocation newLocation = new GridLocation(3, 1);

        // Act
        gameStateTracker.AddNewLocation(newLocation);

        // Assert
        Assert.Equal(newLocation, gameStateTracker.CurrentLocation);
    }

    [Fact]
    public void AddNewLocation_ShouldTriggerMineHitAndLoseLife_WhenSteppingOnMine()
    {
        // Arrange
        IMineFieldGenerator mineFieldGenerator = CreateFakeMineFieldGenerator();
        IGameStateTracker gameStateTracker = new GameStateTracker(mineFieldGenerator);
        IGridLocation mineLocation = new GridLocation(2, 2);
        bool mineHitTriggered = false;
        gameStateTracker.MineHit += () => mineHitTriggered = true;

        // Act
        gameStateTracker.AddNewLocation(mineLocation);

        // Assert
        Assert.True(mineHitTriggered);
        Assert.Equal(3, gameStateTracker.LivesLeft);
    }

    [Fact]
    public void AddNewLocation_ShouldTriggerGameLost_WhenOutOfLives()
    {
        // Arrange
        IMineFieldGenerator mineFieldGenerator = CreateFakeMineFieldGenerator();
        IGameStateTracker gameStateTracker = new GameStateTracker(mineFieldGenerator);
        List<IGridLocation> mineLocations = new List<IGridLocation>
        {
            new GridLocation(2, 2),
            new GridLocation(4, 1),
            new GridLocation(3, 3),
            new GridLocation(1, 5)
        };
        bool gameLostTriggered = false;
        gameStateTracker.GameLost += () => gameLostTriggered = true;

        // Act
        foreach (IGridLocation location in mineLocations)
        {
            gameStateTracker.AddNewLocation(location);
        }

        // Assert
        Assert.True(gameLostTriggered);
        Assert.Equal(0, gameStateTracker.LivesLeft);
    }

    [Fact]
    public void AddNewLocation_ShouldTriggerGameWon_WhenReachedLastRow()
    {
        // Arrange
        IMineFieldGenerator mineFieldGenerator = CreateFakeMineFieldGenerator();
        IGameStateTracker gameStateTracker = new GameStateTracker(mineFieldGenerator);
        List<IGridLocation> safeLocations = new List<IGridLocation>
        {
            new GridLocation(3, 1),
            new GridLocation(3, 2),
            new GridLocation(3, 3),
            new GridLocation(3, 4),
            new GridLocation(3, 5),
            new GridLocation(3, 6),
            new GridLocation(3, 7)
        };
        bool gameWonTriggered = false;
        gameStateTracker.GameWon += () => gameWonTriggered = true;

        // Act
        foreach (IGridLocation location in safeLocations)
        {
            gameStateTracker.AddNewLocation(location);
        }

        // Assert
        Assert.True(gameWonTriggered);
    }
}

