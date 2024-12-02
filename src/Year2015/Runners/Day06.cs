using AdventOfCode.Commons;
using Year2015.Solvers;
using static Year2015.Solvers.Instruction.CommandType;

namespace Year2015.Runners;

public class Day06 : TestEngine<Solvers.Day06, IEnumerable<Instruction>, int>
{
    public override Puzzle PartOne => new()
    {
        Example = new TestEngine<Solvers.Day06, IEnumerable<Instruction>, int>.Example()
        {
            Input = [new("turn on 0,0 through 999,999"), new("toggle 0,0 through 999,0"), new("turn off 499,499 through 500,500")],
            Result = 998996
        },
        Solution = 569999
    };

    public override Puzzle PartTwo => new()
    {
        Example = new TestEngine<Solvers.Day06, IEnumerable<Instruction>, int>.Example()
        {
            Input = [new("toggle 0,0 through 999,999")],
            Result = 2000000
        },
        Solution = 17836115
    };
}
