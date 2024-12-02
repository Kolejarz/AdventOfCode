using AdventOfCode.Commons;
using System.Security.Cryptography;
using System.Text;

namespace Year2015.Solvers;

public class Day04 : Solver<string, int>
{
    public Day04() : base(2015, 4)
    {
    }

    public override string ParseInput(IEnumerable<string> input) => input.First();

    public override int PartOne(string input)
    {
        for (int i = 0; i < 1000000; i++)
        {
            var hashInput = $"{input}{i}";
            var inputBytes = Encoding.ASCII.GetBytes(hashInput);
            var hashBytes = MD5.HashData(inputBytes);
            var hash = Convert.ToHexString(hashBytes);

            if (hash.StartsWith("00000"))
            {
                return i;
            }
        }

        return int.MinValue;
    }

    // TODO: Run in parallel
    public override int PartTwo(string input)
    {
        for (int i = 0; i < int.MaxValue; i++)
        {
            var hashInput = $"{input}{i}";
            var inputBytes = Encoding.ASCII.GetBytes(hashInput);
            var hashBytes = MD5.HashData(inputBytes);
            var hash = Convert.ToHexString(hashBytes);

            if (hash.StartsWith("000000"))
            {
                return i;
            }
        }

        return int.MinValue;
    }
}
