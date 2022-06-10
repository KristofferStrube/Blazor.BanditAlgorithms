namespace KristofferStrube.Blazor.BanditAlgorithms;

public class StaticDataSet : IDataSet
{
    public double[] NormalizedRewards { get; set; }

    public StaticDataSet(double[] rewards)
    {
        var max = rewards.Max();
        NormalizedRewards = rewards.Select(reward => reward / max).ToArray();
    }

    public (double reward, double regret) Choose(int action)
    {
        return (NormalizedRewards[action], 1 - NormalizedRewards[action]);
    }
}
