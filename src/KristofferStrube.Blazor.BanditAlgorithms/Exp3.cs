namespace KristofferStrube.Blazor.BanditAlgorithms;

public class Exp3 : IBanditAlgorithm
{
    private double _lastDrawnProbability;

    public Exp3(int k, double gamma)
    {
        K = k;
        Gamma = gamma;
        Weights = new double[k];
    }

    public Exp3(Exp3 prototype) {
        Weights = prototype.Weights;
        K = prototype.K;
        Gamma = prototype.Gamma;
    }

    public double[] Weights { get; private set; }
    public int K { get; init; }
    public double Gamma { get; init; }

    public int Choose()
    {
        // Calculating propabilities using Sum Of Powers Trick
        double maxWeight = Weights.Max();
        double sumReducedPowerWeights = Weights
            .Sum(w => Math.Exp(Gamma / K * (w - maxWeight)));
        IEnumerable<double> probabilities = Weights
            .Select(w => (1.0 - Gamma) * Math.Exp(Gamma / K * (w - maxWeight) - Math.Log(sumReducedPowerWeights)) + Gamma / K);

        // Sampling using a cummulative sum of the probabilities
        IEnumerable<double> cumProbabilities = probabilities
            .Aggregate(
                Enumerable.Empty<double>(),
                (list, probability) => list.Append((list.Count() > 0 ? list.Last() : 0) + probability)
            );
        double rand = Random.Shared.NextDouble();
        int sample = cumProbabilities.TakeWhile(cum => cum < rand).Count();

        _lastDrawnProbability = probabilities.ElementAt(sample);
        Console.WriteLine(probabilities.Sum());
        return sample;
    }

    public void GiveReward(int action, double feedback)
    {
        double EstimatedReward = feedback / _lastDrawnProbability;
        Weights[action] += EstimatedReward;
    }
}
