using System.Diagnostics.CodeAnalysis;

namespace DesignPatterns.Source.Behavioral;

public interface IIterator
{
    bool MoveNext([NotNullWhen(true)] out string? entry);
}

public class RandomIterator(IList<string> list) : IIterator
{
    private readonly IList<int> remainingIndices = list.Select((_, i) => i).ToList();

    public bool MoveNext([NotNullWhen(true)] out string? entry)
    {
        if (remainingIndices.Count == 0)
        {
            entry = null;
            return false;
        }

        var index = Random.Shared.Next(0, remainingIndices.Count);
        entry = list[remainingIndices[index]];
        remainingIndices.RemoveAt(index);
        return remainingIndices.Count > 0;
    }
}

public class BackwardsIterator(IList<string> list) : IIterator
{
    private int index = list.Count - 1;

    public bool MoveNext([NotNullWhen(true)] out string? entry)
    {
        if (index < 0)
        {
            entry = null;
            return false;
        }

        entry = list[index--];
        return index >= 0;
    }
}