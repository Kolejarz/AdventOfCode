using AdventOfCode.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Year2024.Solvers;

public class Day03 : Solver<List<ProgramOperation>, int>
{
    public Day03() : base(2024, 3)
    {
    }

    public override List<ProgramOperation> ParseInput(IEnumerable<string> input)
    {
        return Regex.Matches(string.Join(string.Empty, input), @"mul\((\d+),(\d+)\)|do\(\)|don't\(\)")
            .Select(m => new ProgramOperation(m.Value)).ToList();
    }

    public override int PartOne(List<ProgramOperation> input)
    {
        var multiplies = input.Where(x => x.Operation == ProgramOperation.OperationType.MULTIPLY);
        return multiplies.Sum(x => x.Parameters[0] * x.Parameters[1]);
    }

    public override int PartTwo(List<ProgramOperation> input)
    {
        var enabled = true;
        var sum = 0;
        foreach(var op in input)
        {
            if(op.Operation == ProgramOperation.OperationType.DO) enabled = true;
            else if(op.Operation == ProgramOperation.OperationType.DONT) enabled = false;

            if (!enabled || op.Operation != ProgramOperation.OperationType.MULTIPLY) continue;

            sum += op.Parameters[0] * op.Parameters[1];
        }

        return sum;
    }
}

public class ProgramOperation
{
    public OperationType Operation { get; init; }
    public int[] Parameters { get; init; }

    public ProgramOperation(string input)
    {
        var op = input.Split('(');
        Operation = op[0] switch
        {
            "mul" => OperationType.MULTIPLY,
            "do" => OperationType.DO,
            "don't" => OperationType.DONT,
            _ => throw new ArgumentException()
        };

        if(Operation == OperationType.MULTIPLY)
        {
            Parameters = Regex.Match(input, @"(\d+),(\d+)").Groups.Values.Skip(1).Select(x => int.Parse(x.Value)).ToArray();
        }
    }

    public enum OperationType
    {
        MULTIPLY,
        DO,
        DONT
    }
}
