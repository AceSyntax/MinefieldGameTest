using GameCommon;
using GameInterfaces;
using GameModels;

namespace GameBehaviour;

public class MineFieldGenerator : IMineFieldGenerator
{
    public List<IMine> GenerateMines(int numberOfMines)
    {
        Random randomNumberGenerator = new Random();

        // Generate the locations of the mines, but don't allow mines in the first row, got to give them a chance :)
        return Enumerable.Range(0, numberOfMines)
             .Select(r => new Mine(new GridLocation(randomNumberGenerator.Next(1, BoardLimits.NumberOfLettersOnBoard), 
                    randomNumberGenerator.Next(1, BoardLimits.NumberOfLettersOnBoard))) as IMine).ToList();

    }
}