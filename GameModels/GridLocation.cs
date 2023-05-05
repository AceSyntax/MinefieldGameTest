using GameInterfaces;

namespace GameModels;

public class GridLocation : IGridLocation
{
    public GridLocation(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; init; }
    public int Y { get; init; }


    public char YtoChar()
    {
        int codePoint = 65 + Y;
        return (char)codePoint;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        GridLocation other = (GridLocation)obj;
        return X == other.X && Y == other.Y;
    }

    public override int GetHashCode()
    {
        return (X * 397) ^ Y;
    }
}