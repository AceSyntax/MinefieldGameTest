using GameInterfaces;

namespace GameModels;

public class Move : IMove
{
    public Move(ConsoleKey keyPressed)
    {
        Key = keyPressed;
    }


    public ConsoleKey Key { get; init; }

    public IGridLocation GetNewGridLocation(IGridLocation currentGridLocation)
    {
        switch (Key)
        {
            case ConsoleKey.UpArrow: return new GridLocation(currentGridLocation.X, currentGridLocation.Y + 1);
            case ConsoleKey.DownArrow: return new GridLocation(currentGridLocation.X, currentGridLocation.Y - 1);
            case ConsoleKey.LeftArrow: return new GridLocation(currentGridLocation.X - 1, currentGridLocation.Y);
            case ConsoleKey.RightArrow: return new GridLocation(currentGridLocation.X + 1, currentGridLocation.Y);
            default: return new GridLocation(-1, -1);

        }
    }
}