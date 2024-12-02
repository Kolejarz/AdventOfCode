using AdventOfCode.Commons;
using Validator = Year2024.Solvers.RedNosedReactorLevelsReportValidator;

namespace Year2024.Solvers;

public class Day02 : Solver<IEnumerable<RedNosedReactorLevelsReport>, int>
{
    public Day02() : base(2024, 2)
    {
    }

    public override IEnumerable<RedNosedReactorLevelsReport> ParseInput(IEnumerable<string> input) => 
        input.Select(x => new RedNosedReactorLevelsReport(x));

    public override int PartOne(IEnumerable<RedNosedReactorLevelsReport> input) => 
        input.Where(r => Validator.IsReportSafe(r.Sequence)).Count();

    public override int PartTwo(IEnumerable<RedNosedReactorLevelsReport> input) => 
        input.Where(r => Validator.IsReportSafe(r.Sequence) || r.DampedReports().Any(dr => Validator.IsReportSafe(dr))).Count();
}

public class RedNosedReactorLevelsReport
{
    public int[] Sequence { get; init; }

    public RedNosedReactorLevelsReport(string input)
    {
        Sequence = input.Split().Select(int.Parse).ToArray();
    }

    public IEnumerable<int[]> DampedReports()
    {
        for (var i = 0; i <  Sequence.Length; i++)
        {
            yield return Sequence[..i].Concat(Sequence[(i+1)..]).ToArray();
        }
    }
}

public static class RedNosedReactorLevelsReportValidator
{
    public static bool IsReportSafe(int[] report)
    {
        bool? increasingSequence = null;
        for(var i = 0; i < report.Length - 1; i++)
        {
            var diff = report[i] - report[i + 1];
            increasingSequence ??= diff < 0;
            if (Math.Abs(diff) is < 1 or > 3) return false;
            if ((increasingSequence == true && diff > 0) || (increasingSequence == false && diff < 0)) return false;
        }

        return true;
    }
}