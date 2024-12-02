using AdventOfCode.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Year2024.Solvers
{
    public class Day02 : Solver<List<int[]>, int>
    {
        public Day02() : base(2024, 2)
        {
        }

        public override List<int[]> ParseInput(IEnumerable<string> input) =>
            input.Select(x => x.Split().Select(y => int.Parse(y.Trim())).ToArray()).ToList();

        public override int PartOne(List<int[]> input)
        {
            var safeReports = 0;
            foreach(var reportInput in input)
            {
                var report = reportInput;
                var isSafe = true;
                if (report[0] < report[1]) report = report.Reverse().ToArray();
                for(var i = 0; i < report.Length - 1; i++)
                {
                    if (report[i] - report[i + 1] is >= 1 and <= 3) continue;
                    else
                    {
                        isSafe = false;
                        break;
                    }
                }

                safeReports += isSafe ? 1 : 0;
            }

            return safeReports;
        }

        public override int PartTwo(List<int[]> input)
        {
            var safeReports = 0;
            foreach (var reportInput in input)
            {
                var addToSafe = false;
                for (var x = -1; x < reportInput.Length; x++)
                {
                    List<int> report = new ();
                    if (x < 0) report = reportInput.ToList();
                    else report = reportInput[0..x].Concat(reportInput[(x+1)..]).ToList();

                    var isSafe = IsReportSafe(report.ToList());
                    if (isSafe)
                    {
                        addToSafe = true;
                        break;
                    }
                }

                safeReports += addToSafe ? 1 : 0;
            }

            return safeReports;
        }

        private static bool IsReportSafe(List<int> report)
        {
            if (report[0] < report[1]) report.Reverse();

            for(var i = 0; i < report.Count - 1; i++)
            {
                if (report[i] - report[i + 1] is < 1 or > 3) return false;
            }

            return true;
        }
    }
}
