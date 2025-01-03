﻿using AdventOfCode.Commons;
using Year2024.Solvers;

namespace Year2024.Runners;

public class Day08 : TestEngine<Solvers.Day08, AntennasMap, int>
{
    private static string Map = @"............
........0...
.....0......
.......0....
....0.......
......A.....
............
............
........A...
.........A..
............
............";

    public override Puzzle PartOne => new () { Example = new() { Input = new AntennasMap(Map.Split(Environment.NewLine)), Result = 14 }, Solution = 1 };

    public override Puzzle PartTwo => new() { Example = new() { Input = new AntennasMap(Map.Split(Environment.NewLine)), Result = 34 }, Solution = 0 };
}
