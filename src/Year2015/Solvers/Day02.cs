using AdventOfCode.Commons;
using System.Text.RegularExpressions;

namespace Year2015.Solvers;

public class Day02 : Solver<IEnumerable<Dimensions>, int>
{
    public Day02() : base(2015, 2)
    {
    }

    public override IEnumerable<Dimensions> ParseInput(IEnumerable<string> input) => input.Select(x => new Dimensions(x));

    public override int PartOne(IEnumerable<Dimensions> input) =>
        input.Sum(x => BoxArea(x) + SmallestSide(x));

    public override int PartTwo(IEnumerable<Dimensions> input) =>
        input.Sum(x => BoxVolume(x) + RibbonLength(x));

    private static int BoxArea(Dimensions dimensions) =>
        2 * dimensions.Width * dimensions.Height +
        2 * dimensions.Height * dimensions.Length +
        2 * dimensions.Length * dimensions.Width;

    private static int BoxVolume(Dimensions dimensions) => dimensions.Length * dimensions.Width * dimensions.Height;

    private static int SmallestSide(Dimensions dimensions) => dimensions.Sizes.Order().Take(2).Aggregate(1, (a, b) => a * b);

    private static int RibbonLength(Dimensions dimensions) => dimensions.Sizes.Order().Take(2).Sum() * 2;
}

public readonly struct Dimensions
{
    public Dimensions(string input)
    {
        var match = Regex.Match(input, @"(\d+).(\d+).(\d+)");
        Length = int.Parse(match.Groups[1].Value);
        Width = int.Parse(match.Groups[2].Value);
        Height = int.Parse(match.Groups[3].Value);
    }

    public int[] Sizes => [Length, Width, Height];

    public int Length { get; init; }
    public int Width { get; init; }
    public int Height { get; init; }
}
