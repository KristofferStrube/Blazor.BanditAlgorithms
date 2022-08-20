using System.Text;

namespace KristofferStrube.Blazor.BanditAlgorithms.BlazorWasm;

public class RegretLineCalculator
{
    public string RegretLine(double[] regrets)
    {
        var count = regrets.Length;
        if (count > 2)
        {
            var minRegret = regrets.Min();
            var maxRegret = regrets.Max();
            if (maxRegret == 0)
            {
                return "";
            }
            return PathData(regrets.Select((r, i) => (x: 20 + (double)i / count * 260.0, y: 280.0 - (r - minRegret) / (maxRegret - minRegret) * 260.0)).ToArray());
        }
        else
        {
            return "";
        }
    }

    private string PathData((double x, double y)[] Points)
    {
        var sb = new StringBuilder();
        if (Points.Length >= 2)
        {
            sb.Append($"M {(int)Points[0].x} {(int)Points[0].y} ");
            sb.AppendJoin("", Points[1..].Select(p => $"L {(int)p.x} {(int)p.y} "));
        }
        return sb.ToString();
    }
}
