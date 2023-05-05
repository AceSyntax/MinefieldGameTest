namespace GameInterfaces;

public interface IMineFieldGenerator
{
    List<IMine> GenerateMines(int numberOfMines);
}