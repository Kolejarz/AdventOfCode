using AdventOfCode.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Year2024.Solvers;

namespace Year2024.Runners;

public class Day06 : TestEngine<Year2024.Solvers.Day06, LabMap, int>
{
    private static string Input = 
@"....#.....
.........#
..........
..#.......
.......#..
..........
.#..^.....
........#.
#.........
......#...";

    public override Puzzle PartOne => new()
    {
        Example = new()
        {
            Input = new(Input.Split(Environment.NewLine)),
            Result = 41
        },
        Solution = 5067
    };

    public override Puzzle PartTwo => PartOne with { Example = PartOne.Example with { Result = 6 }, Solution = 1793 };
}
