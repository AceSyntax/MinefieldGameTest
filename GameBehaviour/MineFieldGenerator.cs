using GameCommon;
using GameInterfaces;
using GameModels;

namespace GameBehaviour;


public class MineFieldGenerator : IMineFieldGenerator
{
    public List<IMine> GenerateMines(int numberOfMines)
    {
        Random randomNumberGenerator = new Random();
        HashSet<GridLocation> locations = new HashSet<GridLocation>();

        // Generate the locations of the mines, but don't allow mines in the first row, got to give them a chance :)
        while (locations.Count < numberOfMines)
        {
            GridLocation location = new GridLocation(randomNumberGenerator.Next(1, BoardLimits.NumberOfLettersOnBoard),
                randomNumberGenerator.Next(1, BoardLimits.NumberOfLettersOnBoard));
            
            if (locations.Add(location))
            {
                // The location was added successfully, so we know we have unique locations.
            }
        }

        return locations.Select(location => new Mine(location) as IMine).ToList();
    }
}