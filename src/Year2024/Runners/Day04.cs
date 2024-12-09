using AdventOfCode.Commons;
using Year2024.Solvers;

namespace Year2024.Runners;

public class Day04 : TestEngine<Year2024.Solvers.Day04, WordSearch, int>
{
    public override Puzzle PartOne => new()
    {
        Example = new Example()
        {
            Input = new WordSearch(new string[] {
                "MMMSXXMASM",
                "MSAMXMSMSA",
                "AMXSXMAAMM",
                "MSAMASMSMX",
                "XMASAMXAMM",
                "XXAMMXXAMA",
                "SMSMSASXSS",
                "SAXAMASAAA",
                "MAMMMXMMMM",
                "MXMXAXMASX"
            }),
            Result = 18                        
        },
        Solution = 1
    };

    public override Puzzle PartTwo => new()
    {
        Example = new Example()
        {
            Input = new WordSearch(new string[] {
                "MMMSXXMASM",
                "MSAMXMSMSA",
                "AMXSXMAAMM",
                "MSAMASMSMX",
                "XMASAMXAMM",
                "XXAMMXXAMA",
                "SMSMSASXSS",
                "SAXAMASAAA",
                "MAMMMXMMMM",
                "MXMXAXMASX"
            }),
            Result = 9
        },
        Solution = 1
    };
}
