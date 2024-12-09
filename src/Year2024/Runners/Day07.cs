using AdventOfCode.Commons;
using Year2024.Solvers;

namespace Year2024.Runners;

public class Day07 : TestEngine<Solvers.Day07, IEnumerable<EquationParameters>, long>
{
    private static string[] Input =>
        @"190: 10 19
3267: 81 40 27
83: 17 5
156: 15 6
7290: 6 8 6 15
161011: 16 10 13
192: 17 8 14
21037: 9 7 18 13
292: 11 6 16 20".Split(Environment.NewLine);

    public override Puzzle PartOne => new() { Example = new() { Input = Input.Select(x => new EquationParameters(x)), Result = 3749 }, Solution = 1298103531759 };

    public override Puzzle PartTwo => PartOne with { Example = PartOne.Example with { Result = 11387 }, Solution = 1 };
}
