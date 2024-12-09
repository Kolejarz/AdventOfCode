using AdventOfCode.Commons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year2024.Solvers;

public class Day06 : Solver<LabMap, int>
{
    public Day06() : base(2024, 6)
    {
    }

    public override LabMap ParseInput(IEnumerable<string> input) => new(input);

    public override int PartOne(LabMap input)
    {
        var visited = new HashSet<(int X, int Y)>();
        do
        {
            visited.Add(input.Position);
        } while (input.NextMove() != null);

        return visited.Count();
    }

    public override int PartTwo(LabMap input)
    {
        var originalMap = new char[input.Map.GetLength(0), input.Map.GetLength(1)];
        for (var x = 0; x < input.Map.GetLength(0); x++)
        {
            for (var y = 0; y < input.Map.GetLength(1); y++)
            {
                originalMap[x, y] = input.Map[x, y];
            }
        }

                var loopCounter = 0;
        for(var x = 0; x < input.Map.GetLength(0); x++)
        {
            for(var y = 0; y < input.Map.GetLength(1); y++)
            {
                input.SetMap(originalMap);
                input.PlaceObstacle(x, y);
                var stepsCounter = 0;
                var visited = new HashSet<(int X, int Y)>();

                do
                {
                    if (!visited.Add(input.Position))
                    {
                        stepsCounter++;
                    }
                    else stepsCounter = 0;
                } while (input.NextMove() != null && stepsCounter < visited.Count);

                if (stepsCounter >= visited.Count) 
                {
                    loopCounter++;
                };
            }
        }

        return loopCounter;
    }
}

public class LabMap
{
    private readonly char[] knownChars = new char[] { '<', '>', 'v', '^' };
    public char[,] Map { get; private set; }
    public (int X, int Y) Position { get; private set; }
    public Direction Direction { get; private set; }

    public LabMap(IEnumerable<string> input)
    {
        Map = new char[input.Count(), input.First().Length];

        for (var i = 0; i < input.Count(); i++)
        {
            for(var j = 0; j < input.First().Length; j++)
            {
                var elem = input.ElementAt(i)[j];
                Map[j, i] = elem;

                if(knownChars.Contains(elem))
                {
                    Position = (j, i);
                    Direction = elem switch
                    {
                        '<' => Solvers.Direction.Left,
                        '>' => Solvers.Direction.Right,
                        '^' => Solvers.Direction.Up,
                        'v' => Solvers.Direction.Down
                    };
                }
            }
        }
    }

    public char? NextSymbol()
    {
        try
        {
            return Direction switch
            {
                Solvers.Direction.Left => Map[Position.X - 1, Position.Y],
                Solvers.Direction.Right => Map[Position.X + 1, Position.Y],
                Solvers.Direction.Up => Map[Position.X, Position.Y - 1],
                Solvers.Direction.Down => Map[Position.X, Position.Y + 1],
            };
        }
        catch
        {
            return null;
        }
    }

    public (int X, int Y)? NextMove()
    {
        try
        {
            var nextSymbol = NextSymbol();
            if (nextSymbol != '#')
            {
                Map[Position.X, Position.Y] = '.';
                Position = Direction switch
                {
                    Solvers.Direction.Left => Position with { X = Position.X - 1 },
                    Solvers.Direction.Right => Position with { X = Position.X + 1 },
                    Solvers.Direction.Up => Position with { Y = Position.Y - 1 },
                    Solvers.Direction.Down => Position with { Y = Position.Y + 1 }
                };
            }
            else
            {
                Direction = Direction switch
                {
                    Direction.Left => Direction.Up,
                    Direction.Up => Direction.Right,
                    Direction.Right => Direction.Down,
                    Direction.Down => Direction.Left
                };
                NextMove();
            }

            Map[Position.X, Position.Y] = Direction switch
            {
                Solvers.Direction.Left => '<',
                Solvers.Direction.Right => '>',
                Solvers.Direction.Up => '^',
                Solvers.Direction.Down => 'v'
            };

            return Position;
        }
        catch
        {
            return null;
        }
    }

    public void PlaceObstacle(int x, int y)
    {
        if((x, y) != Position) Map[x, y] = '#';
    }

    public void SetMap(char[,] input)
    {
        for (var x = 0; x < input.GetLength(0); x++)
        {
            for (var y = 0; y < input.GetLength(1); y++)
            {
                var elem = input[x,y];
                Map[x,y] = elem;

                if (knownChars.Contains(elem))
                {
                    Position = (x, y);
                    Direction = elem switch
                    {
                        '<' => Solvers.Direction.Left,
                        '>' => Solvers.Direction.Right,
                        '^' => Solvers.Direction.Up,
                        'v' => Solvers.Direction.Down
                    };
                }
            }
        }
    }
}

public enum Direction
{
    Left,
    Up,
    Right,
    Down
}