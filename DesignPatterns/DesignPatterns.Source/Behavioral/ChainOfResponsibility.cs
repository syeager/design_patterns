namespace DesignPatterns.Source.Behavioral;

/*
 * thoughts
 * - why linked list instead of a collection in the pipeline?
 *   - the latter could allow for better logging
 *   - would it also make it easy to return the end value?
 *   - can parallelize it if needed
 *   - linked list would increase the stack
 * - this vs decorator
 *  - maybe CoR allows nodes to end the chain while decorator always calls every layer?
 * - is my input & processor pattern just chain of responsibility but instead of passing the input to all the processors (like in CoR) it has a dictionary and knows what processor to call based on the input type?
 *  - unless the processor was chosen not just by input type but also by a runtime value within the input?
 */

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
