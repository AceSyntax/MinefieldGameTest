namespace GameInterfaces;

public interface IGameStateTracker
{
    void AddNewLocation(IGridLocation newGridLocation);

    string PublishLastStateChange();

    void Initialize();

    IGridLocation CurrentLocation { get; }

    event Action MineHit;

    int LivesLeft { get; }

    int Score { get; }

    event Action GameLost;

    event Action GameWon;
}