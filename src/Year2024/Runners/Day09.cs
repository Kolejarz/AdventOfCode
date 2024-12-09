using AdventOfCode.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year2024.Runners;

public class Day09 : TestEngine<Solvers.Day09, List<int?>, long>
{
    public override Puzzle PartOne => new()
    {
        Example = new()
        {
            Input = Solvers.Day09.GetMemory("2333133121414131402"),
            Result = 1928
        },
        Solution = 6421128769094L
    };

    public override Puzzle PartTwo => new()
    {
        Example = new()
        {
            Input = Solvers.Day09.GetMemory("2333133121414131402"),
            Result = 2858
        },
        Solution = 6448168620520L
    };
}
