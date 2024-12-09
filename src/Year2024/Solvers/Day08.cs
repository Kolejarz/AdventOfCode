using AdventOfCode.Commons;
using System.Drawing;

namespace Year2024.Solvers;

public class Day08 : Solver<AntennasMap, int>
{
    public Day08() : base(2024, 8)
    {
    }

    public override AntennasMap ParseInput(IEnumerable<string> input) => new (input);

    public override int PartOne(AntennasMap input) => input.CalculateAntinodes().Count();

    public override int PartTwo(AntennasMap input) => input.CalculateAntinodesPart2().Count();
}

public class AntennasMap
{
    private Size _size { get; init; }

    public IDictionary<char, List<(int X, int Y)>> Antennas { get; init; } = new Dictionary<char, List<(int X, int Y)>>();

    public AntennasMap(IEnumerable<string> input)
    {
        _size = new Size(input.Count(), input.First().Length);

        for (var y = 0; y < _size.Height; y++)
        {
            var line = input.ElementAt(y);
            for(var x = 0; x < _size.Width; x++)
            {
                var tile = line.ElementAt(x);
                if (tile == '.') continue;
                else
                {
                    Antennas.TryAdd(tile, []);
                    Antennas[tile].Add((x, y));
                }
            }
        }
    }

    public IEnumerable<(int X, int Y)> CalculateAntinodes()
    {
        var antinodes = new HashSet<(int X, int Y)>();
        foreach(var antenna in Antennas)
        {
            var positions = antenna.Value;
            foreach (var pivot in positions)
            {
                var remaining = positions.Except([pivot]);
                foreach(var pos in remaining)
                {
                    var xDiff = (pivot.X - pos.X);
                    var yDiff = (pivot.Y - pos.Y);
                    var antinodeLocation = (X: pivot.X + xDiff, Y: pivot.Y + yDiff);

                    if (antinodeLocation.X < 0 || antinodeLocation.Y < 0) continue;
                    if (antinodeLocation.X >= _size.Width || antinodeLocation.Y >= _size.Height) continue;

                    antinodes.Add(antinodeLocation);
                }
            }
        }
        return antinodes;
    }

    public IEnumerable<(int X, int Y)> CalculateAntinodesPart2()
    {
        var antinodes = new HashSet<(int X, int Y)>();
        foreach (var antenna in Antennas)
        {
            var positions = antenna.Value;
            foreach (var pivot in positions)
            {
                var remaining = positions.Except([pivot]);
                foreach (var pos in remaining)
                {
                    var xDiff = (pivot.X - pos.X);
                    var yDiff = (pivot.Y - pos.Y);
                    var distance = 0;

                    while (true)
                    {
                        var antinodeLocation = (X: pivot.X + (xDiff * distance), Y: pivot.Y + (yDiff * distance));

                        if (antinodeLocation.X < 0 || antinodeLocation.Y < 0) break;
                        if (antinodeLocation.X >= _size.Width || antinodeLocation.Y >= _size.Height) break;

                        antinodes.Add(antinodeLocation);
                        distance++;
                    }
                }
            }
        }
        return antinodes;
    }
}
