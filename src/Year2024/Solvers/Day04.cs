using AdventOfCode.Commons;
using System.Text.RegularExpressions;

namespace Year2024.Solvers;

public class Day04 : Solver<WordSearch, int>
{
    public Day04() : base(2024, 4)
    {
    }

    public override WordSearch ParseInput(IEnumerable<string> input)
    {
        return new WordSearch(input);
    }

    public override int PartOne(WordSearch input)
    {
        var count = 0;
        count += CountXmas(input.HorizontalLines);
        count += CountXmas(input.HorizontalLinesReversed);
        count += CountXmas(input.VerticalLines);
        count += CountXmas(input.VerticalLinesReversed);
        count += CountXmas(input.LeftDiagonalLines);
        count += CountXmas(input.LeftDiagonalLinesReversed);
        count += CountXmas(input.RightDiagonalLines);
        count += CountXmas(input.RightDiagonalLinesReversed);

        return count;
    }

    public override int PartTwo(WordSearch input)
    {
        var array = input.HorizontalLines.Select(x => x.ToCharArray()).ToArray();

        var count = 0;
        for(var x = 0; x < array[0].Length; x++)
        {
            for(var y = 0; y < array.Length; y++)
            {
                count += IsXmas(array, x, y) ? 1 : 0;
            }
        }

        return count;
    }

    private int CountXmas(string[] input) => input.Select(x => Regex.Matches(x, @"XMAS")).Sum(x => x.Count);

    private bool IsXmas(char[][] input, int x, int y)
    {
        try
        {
            if (input[x][y] != 'A') return false;
            var topLeft = input[x-1][y-1];
            var topRight = input[x+1][y-1];
            var bottomLeft = input[x-1][y+1];
            var bottomRight = input[x+1][y+1];

            if (topLeft == 'M' && topRight == 'M' &&  bottomLeft == 'S' && bottomRight == 'S') return true;
            if (topLeft == 'S' && topRight == 'S' &&  bottomLeft == 'M' && bottomRight == 'M') return true;
            if (topLeft == 'M' && topRight == 'S' &&  bottomLeft == 'M' && bottomRight == 'S') return true;
            if (topLeft == 'S' && topRight == 'M' &&  bottomLeft == 'S' && bottomRight == 'M') return true;

            return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
}

public class WordSearch
{
    public string[] HorizontalLines { get; init; }
    public string[] HorizontalLinesReversed { get; init; }
    public string[] VerticalLines { get; init; }
    public string[] VerticalLinesReversed { get; init; }
    public string[] LeftDiagonalLines { get; init; }
    public string[] LeftDiagonalLinesReversed { get; init; }
    public string[] RightDiagonalLines { get; init; }
    public string[] RightDiagonalLinesReversed { get; init; }

    public WordSearch(IEnumerable<string> input)
    {
        var array = input.ToArray();
        HorizontalLines = array;
        HorizontalLinesReversed = ReverseLines(array);
        VerticalLines = ParseVerticalLines(array);
        VerticalLinesReversed = ReverseLines(VerticalLines);
        LeftDiagonalLines = ParseDiagonalLines(array);
        LeftDiagonalLinesReversed = ReverseLines(LeftDiagonalLines);
        RightDiagonalLines = ParseDiagonalLines(HorizontalLinesReversed);
        RightDiagonalLinesReversed = ReverseLines(RightDiagonalLines);
    }

    private static string[] ReverseLines(string[] input) => input.Select(x => new string(x.Reverse().ToArray())).ToArray();

    private static string[] ParseVerticalLines(string[] input)
    {
        var result = new string[input[0].Length];

        for(var i = 0; i < input[0].Length; i++)
        {
            foreach(var line in input)
            {
                result[i] ??= result[i];
                result[i] += line[i];
            }
        }

        return result;
    }

    private static string[] ParseDiagonalLines(string[] input)
    {
        var result = new List<string>();

        for (var x = 1; x < input[0].Length; x++)
        {
            var upperDiagonal = string.Empty;
            var lowerDiagonal = string.Empty;

            for(var y = 0; y < input.Length - x; y++)
            {
                var x1 = x + y;
                var y1 = y;
                var x2 = y1;
                var y2 = x1;
                upperDiagonal += input[x1][y1];
                lowerDiagonal += input[x2][y2];
            }

            result.Add(upperDiagonal);
            result.Add(lowerDiagonal);
        }

        // get main diagonal
        var mainDiagonal = string.Empty;
        for(var i = 0; i < input.Length; i++)
        {
            mainDiagonal += input[i][i];
        }
        result.Add(mainDiagonal);

        return [.. result];
    }
}
