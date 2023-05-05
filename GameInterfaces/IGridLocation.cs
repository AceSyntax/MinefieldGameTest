namespace GameInterfaces;

public interface IGridLocation
{
    int X { get; init; }
    int Y { get; init; }

    char YtoChar();
}