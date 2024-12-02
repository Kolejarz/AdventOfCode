using AdventOfCode.Commons;

namespace Year2015.Runners;

public class Day03 : TestEngine<Solvers.Day03, IEnumerable<char>, int>
{
    public override Puzzle PartOne => new()
    {
        Example = new ()
        {
            Input = "^v^v^v^v^v",
            Result = 2
        },
        Solution = 2592
    };

    public override Puzzle PartTwo => new()
    {
        Example = new()
        {
            Input = "^v^v^v^v^v",
            Result = 11
        },
        Solution = 2360
    };
}
