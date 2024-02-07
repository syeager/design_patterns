namespace DesignPatterns.Source.Behavioral;

public class Score
{
    public int Value { get; set; }
}

public interface IScoreHandler
{
    void Handle(Score score);
}

public abstract class ScoreHandler(IScoreHandler next) : IScoreHandler
{
    public virtual void Handle(Score score)
    {
        next.Handle(score);
    }
}

public class Game(IScoreHandler root)
{
    public int Play()
    {
        var score = new Score();
        root.Handle(score);
        return score.Value;
    }
}

public class Double(IScoreHandler next) : ScoreHandler(next)
{
    public override void Handle(Score score)
    {
        score.Value *= 2;
        base.Handle(score);
    }
}

public class PlusOne(IScoreHandler next) : ScoreHandler(next)
{
    public override void Handle(Score score)
    {
        score.Value++;
        base.Handle(score);
    }
}

public class EndGameIfOdd(IScoreHandler next) : ScoreHandler(next)
{
    public override void Handle(Score score)
    {
        if (score.Value % 2 == 0)
        {
            base.Handle(score);
        }
        else
        {
            Console.WriteLine("Ending because of odd number!");
        }
    }
}

public class EndGame() : ScoreHandler(null)
{
    public override void Handle(Score score)
    {
        Console.WriteLine("OVER!");
    }
}
