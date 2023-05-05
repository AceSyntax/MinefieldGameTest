using GameBehaviour;
using GameCommon;
using GameInterfaces;

namespace GameTests
{
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class MineFieldGeneratorTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(5)]
        [InlineData(10)]
        public void GenerateMines_ShouldReturnCorrectNumberOfMines(int numberOfMines)
        {
            // Arrange
            IMineFieldGenerator mineFieldGenerator = new MineFieldGenerator();

            // Act
            List<IMine> mines = mineFieldGenerator.GenerateMines(numberOfMines);

            // Assert
            Assert.Equal(numberOfMines, mines.Count);
        }

        [Fact]
        public void GenerateMines_ShouldNotPlaceMinesInFirstRow()
        {
            // Arrange
            IMineFieldGenerator mineFieldGenerator = new MineFieldGenerator();
            int numberOfMines = 10;

            // Act
            List<IMine> mines = mineFieldGenerator.GenerateMines(numberOfMines);

            // Assert
            foreach (IMine mine in mines)
            {
                Assert.NotEqual(0, mine.Location.X);
            }
        }

        [Fact]
        public void GenerateMines_ShouldPlaceMinesWithinBoardLimits()
        {
            // Arrange
            IMineFieldGenerator mineFieldGenerator = new MineFieldGenerator();
            int numberOfMines = 10;

            // Act
            List<IMine> mines = mineFieldGenerator.GenerateMines(numberOfMines);

            // Assert
            foreach (IMine mine in mines)
            {
                Assert.InRange(mine.Location.X, 1, BoardLimits.NumberOfLettersOnBoard - 1);
                Assert.InRange(mine.Location.Y, 1, BoardLimits.NumberOfLettersOnBoard - 1);
            }
        }

        [Fact]
        public void GenerateMines_ShouldReturnDistinctMineLocations()
        {
            // Arrange
            IMineFieldGenerator mineFieldGenerator = new MineFieldGenerator();
            int numberOfMines = 5;

            // Act
            List<IMine> mines = mineFieldGenerator.GenerateMines(numberOfMines);

            // Assert
            List<IGridLocation> mineLocations = mines.Select(m => m.Location).ToList();
            List<IGridLocation> distinctLocations = mineLocations.Distinct().ToList();
            Assert.Equal(mineLocations.Count, distinctLocations.Count);
        }
    }

}