using DesignPatterns.Source.Behavioral;
using Double = DesignPatterns.Source.Behavioral.Double;

namespace DesignPatterns.Test.Behavioral;

public class ChainOfResponsibilityTest
{
    [Test]
    public void Run()
    {
        var root =
            new PlusOne(
                new PlusOne(
                    new Double(
                        new EndGameIfOdd(
                            new PlusOne(
                                new EndGameIfOdd(
                                    new EndGame()))))));

        var game = new Game(root);

        Console.WriteLine(game.Play());
    }
}