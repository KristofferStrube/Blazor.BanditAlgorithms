namespace KristofferStrube.Blazor.BanditAlgorithms;

public interface IDataSet
{
    public double[] NormalizedRewards { get; set; }
    public (double reward, double weakRegret, double strongRegret) Choose(int action);
}
