namespace KristofferStrube.Blazor.BanditAlgorithms;

public interface IBanditAlgorithm
{
    public double[] Weights { get; }
    public int K { get; }
    public int Choose();
    public void GiveReward(int action, double reward);
}
