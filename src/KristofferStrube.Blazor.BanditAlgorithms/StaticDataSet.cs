namespace KristofferStrube.Blazor.BanditAlgorithms;

public class StaticDataSet : IDataSet
{
    private int _k;
    private int _round;
    private double accumReward;
    private List<double[]> rewardHistory = new();

    public double[] NormalizedRewards { get; set; }

    public StaticDataSet(double[] rewards)
    {
        var max = rewards.Max();
        _k = rewards.Length;
        _round = 0;
        NormalizedRewards = rewards.Select(reward => reward / max).ToArray();
    }

    public (double reward, double weakRegret, double strongRegret) Choose(int action)
    {
        _round++;
        rewardHistory.Add(NormalizedRewards);
        accumReward += NormalizedRewards[action];
        var weakRegret = Enumerable.Range(0, _k).Max(i => rewardHistory.Sum(h => h[i])) - accumReward;
        return (NormalizedRewards[action], weakRegret, _round - accumReward);
    }
}
