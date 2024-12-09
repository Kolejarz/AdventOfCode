using AdventOfCode.Commons;
using System.Data;
using static System.Net.Mime.MediaTypeNames;

namespace Year2024.Solvers;

public class Day05 : Solver<SafetyProtocol, int>
{
    public Day05() : base(2024, 5)
    {
    }

    public override SafetyProtocol ParseInput(IEnumerable<string> input) => new(input);

    public override int PartOne(SafetyProtocol input)
    {
        var correct = new List<int[]>();
        foreach (var update in input.Updates)
        {
            var isCorrect = true;
            for(var i = 0; i < update.Length - 1; i++)
            {
                var current = update[i];
                var next = update[i + 1];
                isCorrect = HasHigherPriority(current, next, input.Ordering);

                if (!isCorrect) break;
            }

            if(isCorrect) correct.Add(update);
        }

        return correct.Select(u => u[u.Length / 2]).Sum();
    }

    public override int PartTwo(SafetyProtocol input)
    {
        var incorrect = new List<int[]>();

        foreach (var update in input.Updates)
        {
            var isCorrect = true;
            for (var i = 0; i < update.Length - 1; i++)
            {
                var current = update[i];
                var next = update[i + 1];
                if (!input.Ordering.TryGetValue(current, out var following) || !following.Contains(next))
                {
                    isCorrect = false;
                    break;
                }
            }

            if (!isCorrect) incorrect.Add(update);
        }

        var correct = new List<int[]>();
        foreach(var broken in incorrect)
        {
            correct.Add(CorrectOrder(broken, input.Ordering));
        }

        return correct.Select(u => u[u.Length / 2]).Sum();
    }

    private int[] CorrectOrder(int[] broken, Dictionary<int, List<int>> ordering)
    {
        var result = new List<int>();
        while (result.Count < broken.Length)
        {
            var remaining = broken.Except(result).ToArray();
            foreach (var number in remaining)
            {
                var exceptCurrent = remaining.Except([number]).ToArray();
                ordering.TryGetValue(number, out var followingNumbers);
                followingNumbers ??= [];
                var precedingNumbers = exceptCurrent.Except(followingNumbers).ToArray();
                if (precedingNumbers.Any()) continue;
                result.Add(number);
                break;
            }
        }

        return result.ToArray();
    }

    private bool HasHigherPriority(int first, int second, Dictionary<int, List<int>> ordering)
    {
        if (!ordering.TryGetValue(first, out var following) || !following.Contains(second))
        {
            return false;
        }
        return true;
    }
}

public class SafetyProtocol
{
    public List<int[]> Updates { get; init; } = new();
    public Dictionary<int, List<int>> Ordering { get; init; } = new();

    public List<(int, int)> Pairs { get; init; } = new();

    public SafetyProtocol(IEnumerable<string> input)
    {
        foreach (var line in input)
        {
            if (line.Contains("|"))
            {
                var parts = line.Split('|');
                var left = int.Parse(parts[0]);
                var right = int.Parse(parts[1]);

                Pairs.Add((left, right));
                if (!Ordering.TryAdd(left, [right])) { Ordering[left].Add(right); }
            }
            else if (line.Contains(","))
            {
                Updates.Add(line.Split(",").Select(int.Parse).ToArray());
            }
        }
    }
}
