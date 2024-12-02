using AdventOfCode.Commons;

namespace Year2024.Solvers;

public class Day01 : Solver<IEnumerable<IEnumerable<int>>, int>
{
    public Day01() : base(2024, 1)
    {
    }

    public override IEnumerable<IEnumerable<int>> ParseInput(IEnumerable<string> input)
    {
        var list1 = new List<int>();
        var list2 = new List<int>();

        foreach (var item in input)
        {
            var parts = item.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            list1.Add(int.Parse(parts[0]));
            list2.Add(int.Parse(parts[1]));
        }

        return new List<List<int>>() { list1, list2 };
    }

    public override int PartOne(IEnumerable<IEnumerable<int>> input)
    {
        var list1 = input.First().Order();
        var list2 = input.Last().Order();

        var result = list1.Zip(list2).Select((pair) => Math.Abs(pair.First - pair.Second)).Sum();
        return result;
    }

    public override int PartTwo(IEnumerable<IEnumerable<int>> input)
    {
        var list1 = input.First().Order();
        var list2 = input.Last().Order().ToList();

        var result = list1.ToDictionary(k => k, v => list2.Count(x => x== v));
        return result.Sum(x => x.Key * x.Value);
    }
}
