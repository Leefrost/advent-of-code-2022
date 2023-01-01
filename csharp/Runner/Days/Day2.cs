namespace Runner.Days;

public static class Day2
{
    public static void Solution(string dataRoot)
    {
        var strategyPoints = 0;
        var secondStrategyPoints = 0;
        
        using var file = File.OpenRead($@"{dataRoot}/day-2.txt");
        using var reader = new StreamReader(file);
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            strategyPoints += GetPoints(line);
            secondStrategyPoints += GetSecondPoints(line);
        }

        Console.WriteLine(strategyPoints);
        Console.WriteLine(secondStrategyPoints);
    }

    private static int GetSecondPoints(string? line)
    {
        var enemy = line[0];
        var result = line[2];

        if (enemy == 'A')
        {
            if (result == 'X')
                return 0 + 3;
            if (result == 'Y')
                return 3 + 1;
            return 6 + 2;
        }
        
        if (enemy == 'B')
        {
            if (result == 'X')
                return 0 + 1;
            if (result == 'Y')
                return 3 + 2;
            return 6 + 3;
        }
        
        if (result == 'X')
            return 0 + 2;
        if (result == 'Y')
            return 3 + 3;
        return 6 + 1;
    }

    private static int GetPoints(string? line)
    {
        var rocks = new[] { 'A', 'X' };
        var paper = new[] { 'B', 'Y' };
        var sci = new[] { 'C', 'Z' };

        var enemy = line[0];
        var hero = line[2];

        if (
            (rocks.Contains(enemy) && rocks.Contains(hero)) || 
             (paper.Contains(enemy) && paper.Contains(hero)) || 
              (sci.Contains(enemy) && sci.Contains(hero)))
        {
            if (rocks.Contains(enemy))
                return 3 + 1;
            if (paper.Contains(enemy))
                return 3 + 2;
            
            return 3 + 3;
        }

        if (rocks.Contains(hero) && sci.Contains(enemy))
        {
            return 1 + 6;
        }
            
        if (paper.Contains(hero) && rocks.Contains(enemy))
        {
            return 2 + 6;
        }
            
        if (sci.Contains(hero) && paper.Contains(enemy))
        {
            return 3 + 6;
        }

        return (rocks.Contains(hero) ? 1 : 0) + (paper.Contains(hero) ? 2 : 0) + (sci.Contains(hero) ? 3 : 0);
    }
}