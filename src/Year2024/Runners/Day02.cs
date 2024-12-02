using AdventOfCode.Commons;

namespace Year2024.Runners
{
    public class Day02 : TestEngine<Year2024.Solvers.Day02, List<int[]>, int>
    {
        public override Puzzle PartOne => new()
        {
            Example = new()
            {
                Input = [
                    [7, 6, 4, 2, 1],
                    [1, 2, 7, 8, 9],
                    [9, 7, 6, 2, 1],
                    [1, 3, 2, 4, 5],
                    [8, 6, 4, 4, 1],
                    [1, 3, 6, 7, 9]
                ],
                Result = 2
            },
            Solution = 213
        };

        public override Puzzle PartTwo => new()
        {
            Example = new()
            {
                Input = [
                    [7, 6, 4, 2, 1],
                    [1, 2, 7, 8, 9],
                    [9, 7, 6, 2, 1],
                    [1, 3, 2, 4, 5],
                    [8, 6, 4, 4, 1],
                    [1, 3, 6, 7, 9]
                ],
                Result = 4
            },
            Solution = 285
        };
    }
}
