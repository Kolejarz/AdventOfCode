using AdventOfCode.Commons;
using Year2015.Solvers;

namespace Year2015.Runners;

public class Day02 : TestEngine<Solvers.Day02, IEnumerable<Dimensions>, int>
{
    public override Puzzle PartOne => new()
    {
        Example = new()
        {
            Input = [
                new Dimensions("2x3x4"),
                new Dimensions("1x1x10")
            ],
            Result = 58 + 43
        },
        Solution = 1598415
    };

    public override Puzzle PartTwo => new()
    {
        Example = new()
        {
            Input = [
                new Dimensions("2x3x4"),
                new Dimensions("1x1x10")
            ],
            Result = 34 + 14
        },
        Solution = 3812909
    };
}
