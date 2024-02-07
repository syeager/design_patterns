namespace DesignPatterns.Source.Behavioral;

public class Buff(IBuffTarget target, string type)
{
    private int buffId;

    public void Apply()
    {
        buffId = target.AddBuff(type);
    }

    public void Remove()
    {
        target.RemoveBuff(buffId);
    }
}

public interface IBuffTarget
{
    int AddBuff(string type);
    void RemoveBuff(int id);
}

public class Player : IBuffTarget
{
    private int buffIndex;
    private Dictionary<int, string> buffs = new();

    public int AddBuff(string type)
    {
        buffs.Add(++buffIndex, type);
        return buffIndex;
    }

    public void RemoveBuff(int id)
    {
        buffs.Remove(id);
    }

    public List<string> ListBuffs()
    {
        return buffs.Select(pair => $"{pair.Key}: {pair.Value}").ToList();
    }
}