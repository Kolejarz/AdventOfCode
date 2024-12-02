using AdventOfCode.Commons;

namespace Year2015.Runners;

public class Day04 : TestEngine<Solvers.Day04, string, int>
{
    public override Puzzle PartOne => new()
    {
        Example = new()
        {
            Input = "abcdef",
            Result = 609043
        },
        Solution = 346386
    };

    public override Puzzle PartTwo => new()
    {
        Example = new()
        {
            Input = "abcdef",
            Result = 6742839
        },
        Solution = 9958218
    };
}
