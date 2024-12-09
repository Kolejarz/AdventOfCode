using AdventOfCode.Commons;
using System.Text;

namespace Year2024.Solvers;

public class Day09 : Solver<List<int?>, long>
{
    public Day09() : base(2024, 09)
    {
    }

    public override List<int?> ParseInput(IEnumerable<string> input) => GetMemory(input.First());

    public override long PartOne(List<int?> input)
    {
        long result = 0;
        for(var i = input.Count - 1; i >= 0; i--) 
        {
            var freeSlot = input.IndexOf(null);
            if (freeSlot < 0 || freeSlot > i) break;
            if (input[i] is null) continue;
            input[freeSlot] = input[i];
            input[i] = null;
        }

        for(int i = 0; i < input.Count; i++)
        {
            if (input[i] is null) continue;
            result += (long)(i * input[i]);
        }

        return result;
    }

    public override long PartTwo(List<int?> input)
    {
        var freeSlots = new List<(int Index, int Size)>();

        for(var i = 0; i < input.Count; i++) 
        {
            var index = i;
            var size = 0;
            if(input[i] is null)
            {
                while (input[index++] is null)
                {
                    size++;
                }
                freeSlots.Add((index - size - 1, size));
                i = index - 1;
            }
        }

        long result = 0;
        for (var i = input.Count - 1; i > 0; i--)
        {
            if (input[i] is null) continue;

            var file = input[i];
            if (file == 0) break;
            var size = 1;
            var originalIndex = i;
            while (input[i-1] == file) 
            { 
                size++;
                i--;
            }

            (int Index, int Size)? freeSlot = freeSlots.Where(x => x.Size >= size && x.Index < i).FirstOrDefault();
            if (freeSlot == (0, 0)) continue;
            for(var x = 0; x < size; x++)
            {
                var ix = freeSlot?.Index + x;
                input[ix.Value] = file;
                var removeAt = originalIndex - x;
                input[removeAt] = null;
            }

            var slotIndex = freeSlots.IndexOf(freeSlot.Value);
            if (freeSlot.Value.Size - size == 0) freeSlots.RemoveAt(slotIndex);
            else freeSlots[slotIndex] = (freeSlot.Value.Index + size, freeSlot.Value.Size - size);
        }

        for (int i = 0; i < input.Count; i++)
        {
            if (input[i] is null) continue;
            result += (long)(i * input[i]);
        }

        return result;
    }

    public static List<int?> GetMemory(string diskMap)
    {
        var result = new List<int?>();

        var fileIndex = 0;
        var isFile = true;
        for (var i = 0; i < diskMap.Length; i++)
        {
            var size = int.Parse(diskMap[i].ToString());
            if (isFile)
            {
                result.AddRange(Enumerable.Repeat((int?)fileIndex++, size));
            }
            else
            {
                result.AddRange(Enumerable.Repeat((int?)null, size));
            }

            isFile = !isFile;
        }

        return result;
    }
}