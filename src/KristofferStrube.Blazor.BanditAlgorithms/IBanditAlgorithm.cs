namespace KristofferStrube.Blazor.BanditAlgorithms;

public interface IBanditAlgorithm
{
    public double[] Weights { get; }
    public int K { get; }
    public int SampleAction();
    public void UpdateWeights(int action, double reward);
}
