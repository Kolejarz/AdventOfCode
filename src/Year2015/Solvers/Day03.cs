using AdventOfCode.Commons;
using System.Drawing;

namespace Year2015.Solvers;

public class Day03 : Solver<IEnumerable<char>, int>
{
    public Day03() : base(2015, 3)
    {
    }

    public override string ParseInput(IEnumerable<string> input) => input.First();

    // TODO: Implement own Point/Position with operators overload
    public override int PartOne(IEnumerable<char> input)
    {
        var visitedHouses = new Dictionary<Point, int>()
        {
            [new Point(0, 0)] = 1
        };

        var position = visitedHouses.First().Key;
        foreach (var move in input)
        {
            position += (Size)GetDirection(move); // bleh, <Point> struct cannot be added to another, .Offset() mutates the struct
            if(!visitedHouses.TryAdd(position, 1))
            {
                visitedHouses[position]++;
            }
        }

        return visitedHouses.Where(h => h.Value > 0).Count();
    }

    public override int PartTwo(IEnumerable<char> input)
    {
        var visitedHouses = new Dictionary<Point, int>()
        {
            [new Point(0, 0)] = 2
        };

        var santaPosition = visitedHouses.First().Key;
        var roboSantaPosition = visitedHouses.First().Key;
        var santaMove = true;
        foreach (var move in input)
        {
            var position = santaMove ? santaPosition : roboSantaPosition;
            position += (Size)GetDirection(move); // bleh, <Point> struct cannot be added to another, .Offset() mutates the struct
            if (!visitedHouses.TryAdd(position, 1))
            {
                visitedHouses[position]++;
            }

            santaPosition = santaMove ? position : santaPosition;
            roboSantaPosition = santaMove ? roboSantaPosition : position;

            santaMove = !santaMove;
        }

        return visitedHouses.Where(h => h.Value > 0).Count();
    }

    private static Point GetDirection(char c) => c switch
    {
        '<' => new Point(-1, 0),
        '>' => new Point(1, 0),
        '^' => new Point(0, 1),
        'v' => new Point(0, -1),
        _ => throw new ArgumentException()
    };
}
