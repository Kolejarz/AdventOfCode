using AdventOfCode.Commons;
using Year2024.Solvers;

namespace Year2024.Runners;

public class Day05 : TestEngine<Solvers.Day05, SafetyProtocol, int>
{
    public override Puzzle PartOne => new TestEngine<Solvers.Day05, SafetyProtocol, int>.Puzzle()
    {
        Example = new()
        {
            Input = new([
                "47|53",
                "97|13",
                "97|61",
                "97|47",
                "75|29",
                "61|13",
                "75|53",
                "29|13",
                "97|29",
                "53|29",
                "61|53",
                "97|53",
                "61|29",
                "47|13",
                "75|47",
                "97|75",
                "47|61",
                "75|61",
                "47|29",
                "75|13",
                "53|13",
                "",
                "75,47,61,53,29",
                "97,61,53,29,13",
                "75,29,13",
                "75,97,47,61,53",
                "61,13,29",
                "97,13,75,29,47"
                ]),
            Result = 143
        },
        Solution = 5452
    };

    public override Puzzle PartTwo => PartOne with { Example = PartOne.Example with { Result = 123 }, Solution = 4598 };
}
