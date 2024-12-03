using AdventOfCode.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Year2024.Solvers;

public class Day03 : Solver<List<(int, int)>, int>
{
    public Day03() : base(2024, 3)
    {
    }

    public override List<(int, int)> ParseInput(IEnumerable<string> input)
    {
        return Regex.Matches(string.Join(string.Empty, input), @"mul\((\d+),(\d+)\)")
            .Select(m => m.Groups)
            .Select(x => (int.Parse(x[1].Value), int.Parse(x[2].Value))).ToList();
    }

    public override int PartOne(List<(int, int)> input)
    {
        return input.Select(x => x.Item1 * x.Item2).Sum();
    }

    public override int PartTwo(List<(int, int)> input)
    {
        throw new NotImplementedException();
    }
}
