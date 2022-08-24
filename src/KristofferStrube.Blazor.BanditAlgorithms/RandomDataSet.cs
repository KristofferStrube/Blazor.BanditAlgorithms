namespace KristofferStrube.Blazor.BanditAlgorithms;

public class RandomDataSet : IDataSet
{
    private int _k;
    private int _round;
    private double accumReward;
    private List<double[]> rewardHistory = new();

    public double[] NormalizedRewards { get; set; }

    public RandomDataSet(int k)
    {
        _k = k;
        _round = 0;
        var rewards = Enumerable.Range(0, _k).Select(_ => Random.Shared.NextDouble()).ToList();
        NormalizedRewards = rewards.Select(i => i / rewards.Sum()).ToArray();
    }

    public (double reward, double weakRegret, double strongRegret) Choose(int action)
    {
        _round++;
        var rewards = Enumerable.Range(0, _k).Select(_ => Random.Shared.NextDouble()).ToList();
        NormalizedRewards = rewards.Select(i => i / rewards.Sum()).ToArray();
        rewardHistory.Add(NormalizedRewards);
        accumReward += NormalizedRewards[action];
        var weakRegret = Enumerable.Range(0, _k).Max(i => rewardHistory.Sum(h => h[i])) - accumReward;
        return (NormalizedRewards[action], weakRegret, _round - accumReward);
    }
}
