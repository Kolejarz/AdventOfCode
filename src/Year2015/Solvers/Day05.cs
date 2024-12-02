using AdventOfCode.Commons;
using System.Text.RegularExpressions;

namespace Year2015.Solvers;

public class Day05 : Solver<IEnumerable<string>, int>
{
    public Day05() : base(2015, 5)
    {
    }

    public override IEnumerable<string> ParseInput(IEnumerable<string> input) => input;

    // TODO: Remove parametrization
    public override int PartOne(IEnumerable<string> input)
    {
        char[] vowels = ['a', 'e', 'i', 'o', 'u'];
        string[] naughtySeuences = ["ab", "cd", "pq", "xy"];
        var niceStrings = input.Where(x => ContainsAtLeastNVowels(x, 3, vowels) && ContainsAtLeastNCharactersInRow(x, 2) && DoesNotContainAnyOf(x, naughtySeuences));
        return niceStrings.Count();
    }

    // TODO: Review possibility to rewrite to LINQ
    public override int PartTwo(IEnumerable<string> input)
    {
        // cannot aplly && to method groups
        var niceStrings = input.Where(ContainsDuplicatedLettersPair).Where(ContainsMirroredLetter);
        return niceStrings.Count();
    }

    private static bool ContainsAtLeastNVowels(string input, int count, char[] vowels) => input.Where(x => vowels.Contains(x)).Count() >= count;

    private static bool ContainsAtLeastNCharactersInRow(string input, int count) => Regex.Match(input, $@"(.)\1{{{--count},}}").Success;

    private static bool DoesNotContainAnyOf(string input, string[] sequences) => !sequences.Any(s => input.Contains(s));

    private static bool ContainsDuplicatedLettersPair(string input)
    {
        var pairs = new HashSet<string>();
        for (var i = 0; i < input.Length - 1; i++)
        {
            var pair = input[i..(i + 2)];
            if (pair != pairs.LastOrDefault() && pairs.Contains(pair))
            {
                return true;
            }

            pairs.Add(pair);
        }

        return false;
    }

    private static bool ContainsMirroredLetter(string input)
    {
        for(var i = 0; i < input.Length - 2; i++)
        {
            var letters = input[i..(i + 3)];
            if (letters.First() == letters.Last()) 
            { 
                return true; 
            }
        }

        return false;
    }
}
