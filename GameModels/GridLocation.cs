using GameInterfaces;

namespace GameModels;

public record GridLocation(int X, int Y) : IGridLocation
{
    public char YtoChar()
    {
        int codePoint = 65 + Y;
        return (char)codePoint;
    }
}