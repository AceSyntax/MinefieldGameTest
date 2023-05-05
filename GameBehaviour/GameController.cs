using GameInterfaces;

namespace GameBehaviour;

public class GameController : IGameController
{
    private INavigator navigator;
    private IGameStateTracker gameStateTracker;
    private IPlayerFeedbackProvider playerFeedbackProvider;
    private bool gameLost;
    private bool gameWon;
    private Func<ConsoleKey> readKey;
    

        public GameController(INavigator navigator, IGameStateTracker gameStateTracker, IPlayerFeedbackProvider playerFeedbackProvider, Func<ConsoleKey> readKey = null)
    {
        // sure, use underscores for private fields or qualify with this, or neither, I'm happy either way
        this.navigator = navigator;
        this.gameStateTracker = gameStateTracker;
        this.gameStateTracker.GameLost += () => gameLost = true;
        this.gameStateTracker.GameWon += () => gameWon = true;
        this.playerFeedbackProvider = playerFeedbackProvider;
        this.readKey = readKey ?? (() => Console.ReadKey(intercept: true).Key);
    }


    public void Initialize()
    {
        // could ask the user for input here, to set the game up.
        gameStateTracker.Initialize();
    }

    public void Run()
    {
        playerFeedbackProvider.GameStarted();

        while (true)
        {
            var key = readKey();
            navigator.Navigate(key);

            if (key == ConsoleKey.Enter || gameLost || gameWon)
            {
                break;
            }
        }

        Stop();

        Console.ReadLine();
    }

    private void Stop()
    {
        if (gameLost)
        {
            playerFeedbackProvider.GameLost();
        }

        if (gameWon)
        {
            playerFeedbackProvider.GameWon();
        }
    }
}