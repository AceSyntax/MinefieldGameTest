using GameInterfaces;

namespace GameModels;

/// <summary>
/// A mine 'has a' location
/// </summary>
public class Mine : IMine
{
    public Mine(IGridLocation location)
    {
        Location = location;
    }
    public IGridLocation Location { get; init; }
}