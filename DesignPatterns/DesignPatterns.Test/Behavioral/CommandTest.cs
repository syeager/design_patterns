using DesignPatterns.Source.Behavioral;

namespace DesignPatterns.Test.Behavioral;

public class CommandTest
{
    [Test]
    public void Run()
    {
        var player = new Player();
        var buffs = new List<Buff>
        {
            new(player, "iron-hide"),
            new(player, "flame-hands"),
            new(player, "iron-hide"),
        };

        PrintBuffs(player);
        foreach (var buff in buffs)
        {
            buff.Apply();
        }
        PrintBuffs(player);
        buffs[1].Remove();
        PrintBuffs(player);
        buffs[0].Remove();
        buffs[2].Remove();
        PrintBuffs(player);
        return;

        static void PrintBuffs(Player player) => Console.WriteLine($"Buffs:{Environment.NewLine}{string.Join(Environment.NewLine, player.ListBuffs())}");
    }
}