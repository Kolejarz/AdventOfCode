using AdventOfCode.Commons;

namespace Year2015.Solvers;

public class Day01 : Solver<string, int>
{
    public Day01() : base(2015, 1) { }

    public override string ParseInput(IEnumerable<string> input) => input.First();

    public override int PartOne(string input)
    {
        var up = input.Count(c => c == '(');
        var down = input.Count(c => c == ')');
        return up - down;
    }

    public override int PartTwo(string input)
    {
        var floor = 0;
        var position = 0;
        while (floor >= 0)
        {
            floor += input[position++] == '(' ? 1 : -1;
        }

        return position;
    }
}
