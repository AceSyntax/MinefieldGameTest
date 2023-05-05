using GameInterfaces;
using GameModels;

namespace GameBehaviour;

/// <summary>
/// Tracks the game state, starting position on row 0/A.  consisting of current position, list of locations, mines hit.
/// </summary>
public class GameStateTracker : IGameStateTracker
{
    private List<IMine> mineField;
    private List<IGridLocation> routeThroughMinefield;
    private int lives;

    public event Action MineHit = null!;
    public event Action? GameLost;
    public event Action? GameWon;

    public GameStateTracker(IMineFieldGenerator mineFieldGenerator)
    {
        routeThroughMinefield = new List<IGridLocation> 
        {
            // add the starting location as 0/0, could use Random to generate a position, or let the user choose.
            new GridLocation(3,0)
        };

        mineField = mineFieldGenerator.GenerateMines(5);
        lives = 4;
    }

    public void AddNewLocation(IGridLocation newGridLocation)
    {
        routeThroughMinefield.Add(newGridLocation);

        if (mineField.Any(m => m.Location.X == newGridLocation.X && m.Location.Y == newGridLocation.Y))
        {
            mineField.Remove(
                mineField.First(m => m.Location.X == newGridLocation.X && m.Location.Y == newGridLocation.Y));

            LooseALife();
        }

        if (newGridLocation.Y == 7)
        {
            WinGame();
        }
    }

    public string PublishLastStateChange()
    {
        return String.Empty;
    }

    public void Initialize(/*tbd*/)
    {
     //tbd   
    }

    private void WinGame()
    {
        GameWon?.Invoke();
    }

    public IGridLocation CurrentLocation => routeThroughMinefield.Last();
    public int LivesLeft => lives;
    public int Score => routeThroughMinefield.Count;

    private void LooseALife()
    {
        --lives;

        MineHit?.Invoke();

        if (lives == 0)
        {
            GameLost?.Invoke();
        }
    }

}