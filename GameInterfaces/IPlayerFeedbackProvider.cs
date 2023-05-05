namespace GameInterfaces;

public interface IPlayerFeedbackProvider
{
    void ProvideFeedback(string message);

    void GameLost();

    void GameStarted();

    void GameWon();

    void InvalidKeyInput();

    void MineHit(int livesLeft);

    void LatestMove(int X, char YasChar, int livesLeft);

    void InvalidMove();
}