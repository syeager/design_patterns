using DesignPatterns.Source.Behavioral;

namespace DesignPatterns.Test.Behavioral;

public class IteratorTest
{
    [Test]
    public void Run()
    {
        var items = new List<string>
        {
            "apple",
            "bat",
            "carrot",
            "dog"
        };

        var random = new RandomIterator(items);
        for (var i = 0; i < items.Count; i++)
        {
            PrintNext(random);
        }

        var backwards = new BackwardsIterator(items);
        for (var i = 0; i < items.Count; i++)
        {
            PrintNext(backwards);
        }

        return;

        static void PrintNext(IIterator iterator)
        {
            var hasMore = iterator.MoveNext(out var entry);
            Console.WriteLine($"{iterator.GetType().Name}: {entry}{(hasMore ? "" : " Done")}");
        }
    }
}