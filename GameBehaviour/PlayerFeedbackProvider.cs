using GameCommon;
using GameInterfaces;

namespace GameBehaviour;

public class PlayerFeedbackProvider : IPlayerFeedbackProvider
{
    public void ProvideFeedback(string message)
    {
        Console.WriteLine(message);
    }

    public void GameLost()
    {
        Console.WriteLine(GamePlayerMessages.GameLost);
    }

    public void GameStarted()
    {
        Console.WriteLine(GamePlayerMessages.StartingMessage);
    }

    public void GameWon()
    {
        Console.WriteLine(GamePlayerMessages.GameWon);
    }

    public void InvalidKeyInput()
    {
        Console.WriteLine(GamePlayerMessages.KeyNotValid);
    }

    public void MineHit(int livesLeft)
    {
        Console.WriteLine(string.Format(GamePlayerMessages.MineHit, livesLeft));
    }

    public void LatestMove(int X, char YasChar, int livesLeft)
    {
        Console.WriteLine(string.Format(GamePlayerMessages.LatestMove, X, YasChar, livesLeft));
    }

    public void InvalidMove()
    {
        Console.WriteLine(GamePlayerMessages.InvalidMove);
    }
}