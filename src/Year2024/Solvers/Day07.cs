using AdventOfCode.Commons;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Year2024.Solvers;

public class Day07 : Solver<IEnumerable<EquationParameters>, long>
{
    public Day07() : base(2024, 7)
    {
    }

    public override IEnumerable<EquationParameters> ParseInput(IEnumerable<string> input) => input.Select(i => new EquationParameters(i));

    public override long PartOne(IEnumerable<EquationParameters> input)
    {
        long sum = 0;
        foreach (var equation in input)
        {
            var upperBound = (int)Math.Pow(2, equation.Tokens.Length - 1);
            var operatorsLength = equation.Tokens.Length - 1;

            var numbers = Enumerable.Range(0, upperBound);
            //Console.WriteLine(string.Join(" ", equation.Tokens));
            //Console.WriteLine($"{numbers.First()} .. {numbers.Last()}");

            foreach (var number in numbers)
            {
                var operators = Operators(number, operatorsLength);
                var equationResult = equation.Solve(operators);
                if (equationResult == equation.Result)
                {
                    //Console.WriteLine($"{sum} + {equation.Result}");
                    sum += equation.Result;
                    //Console.WriteLine($"{equation.BuildExpression(operators)} = {equation.Result}");
                    break;
                }
            }

            //for (var i = operatorsLength; i >= 0; i--)
            //{
            //    var numbers = GetNumbersWithNBitsSet(i, upperBound);
            //    var operators = numbers
            //        .Select(n => Operators(n, operatorsLength))
            //        .OrderBy(x => x.Count(o => o == "*"))
            //        .ThenBy(x => x.ToList().LastIndexOf("*"));

            //    var solutionFound = false;
            //    foreach (var op in operators)
            //    {
            //        if (equation.Solve(op) == equation.Result)
            //        {
            //            sum += equation.Result;
            //            solutionFound = true;
            //            break;
            //        }
            //    }
            //    if (solutionFound) break;
            //}
        }
        
        return sum;
    }

    public override long PartTwo(IEnumerable<EquationParameters> input)
    {
        long sum = 0;
        var ix = 0;
        foreach (var equation in input)
        {
            Console.WriteLine(++ix);
            var upperBound = (int)Math.Pow(2, equation.Tokens.Length - 1);
            var operatorsLength = equation.Tokens.Length - 1;
            var numbers = Enumerable.Range(0, upperBound);
            var solved = false;

            foreach (var number in numbers)
            {
                var operators = Operators(number, operatorsLength);

                foreach (var mask in Enumerable.Range(0, upperBound).Select(x => Convert.ToString(x, 2).PadLeft(operatorsLength, '0')))
                {
                    var maskedOperators = operators.ToArray();
                    for (int i = 0; i < maskedOperators.Length; i++) 
                        if (mask[i] == '1') maskedOperators[i] = "|";

                    var equationResult = equation.Solve(maskedOperators);
                    if (equationResult == equation.Result)
                    {
                        sum += equation.Result;
                        solved = true;
                        break;
                    }
                }                

                if (solved) break;
            }
        }

        return sum;
    }

    private IEnumerable<int> GetNumbersWithNBitsSet(int n, int upperBound)
    {
        for(var i = 0; i < upperBound; i++)
        {
            var binary = Convert.ToString(i, 2);
            if (binary.Count(x => x == '1') == n) yield return i;
        }
    }

    private static string[] Operators(int current, int length)
    {
        var operators = new BitArray(new int[] { current }).ToOperators().Take(length);
        return operators.ToArray();
    }
}

public class EquationParameters
{
    public long Result { get; init; }
    public int[] Tokens { get; init; }

    public EquationParameters(string input)
    {
        var colon = input.IndexOf(':');
        var score = input[0..colon];
        var tokens = input[++colon..];
        Result = long.Parse(score);
        Tokens = tokens.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    }

    public long Solve(params string[] operators)
    {
        if (operators.Length != Tokens.Length - 1) throw new ArgumentException("Invalid length of operators array");

        long result = Tokens.First();
        var tokens = Tokens.Skip(1).ToArray();
        for(var i = 0; i < operators.Length; i++)
        {
            if (operators[i] == "+") result += tokens[i];
            if (operators[i] == "*") result *= tokens[i];
            if (operators[i] == "|") result = long.Parse($"{result}{tokens[i]}");
        }

        return result;
    }

    public string BuildExpression(params string[] operators)
    {
        var expression = new StringBuilder();
        for (var i = 0; i < operators.Length; i++)
        {
            expression.Append($"{Tokens[i]}{operators[i]}");
        }

        expression.Append(Tokens.Last());

        return expression.ToString();
    }
}

public static class BitArrayExtension
{
    public static IEnumerable<string> ToOperators(this BitArray array)
    {
        foreach(var bit in array)
        {
            var value = (bool)bit;
            yield return value ? "*" : "+";
        }
    }
}