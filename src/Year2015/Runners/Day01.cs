using AdventOfCode.Commons;
using System;
namespace Year2015.Runners;

public class Day01 : TestEngine<Solvers.Day01, string, int>
{
    public override Puzzle PartOne => new()
    {
        Example = new ()
        {
            Input = "))(((((",
            Result = 3
        },
        Solution = 74
    };

    public override Puzzle PartTwo => new()
    {
        Example = new()
        {
            Input = "()())",
            Result = 5
        },
        Solution = 1795
    };
}
