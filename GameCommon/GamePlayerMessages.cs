namespace GameCommon;

public class GamePlayerMessages
{
    public const string StartingMessage =
        "Welcome to MyMinesweeper, you can press the Enter key at any time to exit the game. \nUse the cursor keys to navigate the 8x8 grid of danger.\n Enjoy!";

    public const string InvalidMove = "Unable to make that move, you are at the edge of the board!";

    public const string LatestMove = "You have moved to location column {0}, row {1}, current score {2}";

    public const string MineHit = "Kaboom!   You hit a mine!   You have {0} lives left";

    public const string KeyNotValid = "The key you pressed is not valid for navigating the grid of danger";

    public const string GameLost = "Ohhh, sorry you ran out of lives, better luck next time.";

    public const string GameWon = "Yeaaah!, Congratulations! You're a winner!";
}