namespace GameInterfaces;

public interface IMove
{
    ConsoleKey Key { get; init; }

    IGridLocation GetNewGridLocation(IGridLocation existingGridLocation);
}