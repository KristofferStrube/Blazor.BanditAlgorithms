namespace KristofferStrube.Blazor.BanditAlgorithms;

public interface IDataSet
{
    public (double reward, double regret) Choose(int action);
}
