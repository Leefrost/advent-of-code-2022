// See https://aka.ms/new-console-template for more information


var subset = 0;
var callories = new List<int>();

using var file = File.OpenRead("Days//input-1.txt");
using var reader = new StreamReader(file);
while (!reader.EndOfStream)
{
    var line = reader.ReadLine();

    if (line == "")
    {
        callories.Add(subset);
        subset = 0;
    }
    else
    {
        var current = int.Parse(line);
        subset += current;
    }
}

var max = callories.Max();
var topMax = callories.OrderByDescending(x=>x)
    .Take(3).Sum();

Console.WriteLine();