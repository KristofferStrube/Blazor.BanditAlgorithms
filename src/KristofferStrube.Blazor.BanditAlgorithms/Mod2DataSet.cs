using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KristofferStrube.Blazor.BanditAlgorithms;

public class Mod2DataSet : IDataSet
{
    private int _k;
    private int _round;
    private double accumReward;
    private List<double[]> rewardHistory = new();
    public double[] NormalizedRewards { get; set; }

 
    public Mod2DataSet(int k)
    {
        _k = k;
        _round = 0;
        NormalizedRewards = Enumerable.Range(0, _k).Select(i => i % 2 == 0 ? (_round % 2.0) : (_round + 1) % 2.0).ToArray();
    }

    public (double reward, double weakRegret, double strongRegret) Choose(int action)
    {
        _round++;
        NormalizedRewards = Enumerable.Range(0, _k).Select(i => i % 2 == 0 ? (_round/1000 % 2) : (_round / 1000 + 1) % 2.0).ToArray();
        rewardHistory.Add(NormalizedRewards);
        accumReward += NormalizedRewards[action];
        var weakRegret = Enumerable.Range(0, _k).Max(i => rewardHistory.Sum(h => h[i])) - accumReward;
        return (NormalizedRewards[action], weakRegret, _round - accumReward);
    }
}
