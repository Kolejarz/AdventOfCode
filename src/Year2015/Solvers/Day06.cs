using AdventOfCode.Commons;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Year2015.Solvers;

public class Day06 : Solver<IEnumerable<Instruction>, int>
{
    public Day06() : base(2015, 6)
    {
    }

    public override IEnumerable<Instruction> ParseInput(IEnumerable<string> input) => input.Select(x => new Instruction(x));

    // TODO: parse instructions first, then apply to grid?
    public override int PartOne(IEnumerable<Instruction> input)
    {
        bool[,] grid = new bool[1000, 1000];
        foreach (var instruction in input)
        {
            for(var x = 0; x < 1000; x++)
            {
                for (var y = 0; y < 1000; y++)
                {
                    if (IsWithinRange(instruction, new Point(x, y))) continue;

                    grid[x, y] = instruction.Command switch
                    {
                        Instruction.CommandType.On => true,
                        Instruction.CommandType.Off => false,
                        Instruction.CommandType.Toggle => !grid[x, y],
                        _ => throw new ArgumentException()
                    };
                }
            }
        }

        return grid.Cast<bool>().Count(x => x == true);
    }

    public override int PartTwo(IEnumerable<Instruction> input)
    {
        int[,] grid = new int[1000, 1000];
        foreach (var instruction in input)
        {
            for (var x = 0; x < 1000; x++)
            {
                for (var y = 0; y < 1000; y++)
                {
                    if (IsWithinRange(instruction, new Point(x, y))) continue;

                    grid[x, y] += instruction.Command switch
                    {
                        Instruction.CommandType.On => 1,
                        Instruction.CommandType.Off => -1,
                        Instruction.CommandType.Toggle => 2,
                        _ => throw new ArgumentException()
                    };

                    if (grid[x, y] < 0) grid[x, y] = 0;
                }
            }
        }

        return grid.Cast<int>().Sum();
    }

    private static bool IsWithinRange(Instruction instruction, Point point)
    {
        if (point.X < Math.Min(instruction.Corner1.X, instruction.Corner2.X)) return true;
        if (point.X > Math.Max(instruction.Corner1.X, instruction.Corner2.X)) return true;
        if (point.Y < Math.Min(instruction.Corner1.Y, instruction.Corner2.Y)) return true;
        if (point.Y > Math.Max(instruction.Corner1.Y, instruction.Corner2.Y)) return true;

        return false;
    }
}

public struct Instruction
{
    public Instruction(string input)
    {
        var m = Regex.Match(input, @"(on|off|toggle) (\d+),(\d+).* (\d+),(\d+)").Groups;

        Command = m[1].Value switch
        {
            "on" => CommandType.On,
            "off" => CommandType.Off,
            "toggle" => CommandType.Toggle,
            _ => throw new ArgumentException()
        };
        Corner1 = new Point(int.Parse(m[2].Value), int.Parse(m[3].Value));
        Corner2 = new Point(int.Parse(m[4].Value), int.Parse(m[5].Value));
    }

    public Point Corner1 { get; init; }
    public Point Corner2 { get; init; }
    public CommandType Command { get; init; }

    public enum CommandType
    {
        On,
        Off,
        Toggle
    }
}
