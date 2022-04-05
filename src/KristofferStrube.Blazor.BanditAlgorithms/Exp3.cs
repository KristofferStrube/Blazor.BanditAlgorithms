namespace KristofferStrube.Blazor.BanditAlgorithms;

public class Exp3 : IBanditAlgorithm
{
    private double _lastDrawnProbability;

    public Exp3(int k, double eta)
    {
        Weights = new double[k];
        K = k;
        Eta = eta;
    }
    public double[] Weights { get; private set; }
    public int K { get; init; }
    public double Eta { get; init; }

    public int SampleAction()
    {
        IEnumerable<double>? expWeights = Weights.Select(weight => Math.Exp(Eta * weight));

        (IEnumerable<double> cums, double sum) = expWeights
            .Aggregate(
                (cums: Enumerable.Empty<double>(), sum: 0.0),
                (prev, curr) => (prev.cums.Append(prev.sum + curr), prev.sum + curr)
            );

        double rand = Random.Shared.NextDouble();
        int sample = cums.TakeWhile(cum => cum / sum < rand).Count();

        _lastDrawnProbability = expWeights.ElementAt(sample) / sum;
        if (Weights.All(w => w == 0)) _lastDrawnProbability = 1.0 / K;

        return sample;
    }

    public void UpdateWeights(int action, double reward)
    {
        for (int i = 0; i < K; i++)
        {
            Weights[i] = Weights[i] + 1 - (action == i ? 1 : 0) * (1 - reward) / _lastDrawnProbability;
        }
    }
}
