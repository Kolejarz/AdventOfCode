using AdventOfCode.Commons;

namespace Year2015.Solvers;

//public class Day07 : Solver<IEnumerable<Element>, int>
//{
//    public Day07() : base(2015, 7)
//    {
//    }

//    public override IEnumerable<Element> ParseInput(IEnumerable<string> input) => input.Select(input => new Element(input));

//    public override int PartOne(IEnumerable<Element> input)
//    {
//        var dictionary = input.ToDictionary(k => k.Id, v => v);
//    }

//    public override int PartTwo(IEnumerable<Element> input)
//    {
//        throw new NotImplementedException();
//    }
//}


public abstract class Element
{
    public Element(string input)
    {
        var parts = input.Split("->", StringSplitOptions.TrimEntries);
        Input = parts[0];
        Id = parts[1];
    }

    public string Id { get; init; }
    public abstract int Output { get; }
    public string Input { get; init; }
}

public class ValueElement : Element
{
    public ValueElement(string input) : base(input)
    {

    }

    public override int Output => int.Parse(Input);
}