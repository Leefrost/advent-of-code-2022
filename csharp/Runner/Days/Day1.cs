namespace Runner.Days;

public static class Day1
{
    public static void Solution(string dataRoot)
    {
        var subset = 0;
        var calories = new List<int>();

        using var file = File.OpenRead($@"{dataRoot}/day-1.txt");
        using var reader = new StreamReader(file);
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();

            if (line == "")
            {
                calories.Add(subset);
                subset = 0;
            }
            else
            {
                var current = int.Parse(line);
                subset += current;
            }
        }

        var max = calories.Max();
        var topMax = calories.OrderByDescending(x=>x)
            .Take(3).Sum();
        
        Console.WriteLine($"Task 1 - {max}");
        Console.WriteLine($"Task 2 - {topMax}");
    }
}