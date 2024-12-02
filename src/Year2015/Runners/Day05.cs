using AdventOfCode.Commons;

namespace Year2015.Runners;

public class Day05 : TestEngine<Solvers.Day05, IEnumerable<string>, int>
{
    public override Puzzle PartOne => new()
    {
        Example = new()
        {
            Input = ["ugknbfddgicrmopn", "aaa", "jchzalrnumimnmhp", "dvszwmarrgswjxmb", "haegwjzuvuyypxyu"],
            Result = 2
        },
        Solution = 258
    };

    public override Puzzle PartTwo => new()
    {
        Example = new()
        {
            Input = ["qjhvhtzxzqqjkmpb", "xxyxx", "uurcxstgmygtbstg", "ieodomkazucvgmuy"],
            Result = 2
        },
        Solution = 53
    };
}
