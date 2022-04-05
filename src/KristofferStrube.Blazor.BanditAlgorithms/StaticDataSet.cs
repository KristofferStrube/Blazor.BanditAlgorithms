namespace KristofferStrube.Blazor.BanditAlgorithms;

public class StaticDataSet : IDataSet
{
    private double[] _normalizedRewards;

    public StaticDataSet(double[] rewards)
    {
        var max = rewards.Max();
        _normalizedRewards = rewards.Select(reward => reward / max).ToArray();
    }

    public (double reward, double regret) Choose(int action)
    {
        return (_normalizedRewards[action], 1 - _normalizedRewards[action]);
    }
}
