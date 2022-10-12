using System.Collections.Generic;

namespace Optrol.Theory
{
  public class Point
  {
    public double Energy;
    public int id;
    public double[] optCon;
    public List<int> neighbours;
    public double ErrorEstimation;

    public Point(int _id)
    {
      this.Energy = double.PositiveInfinity;
      this.id = _id;
    }
  }
}
