namespace Optrol.Theory
{
  internal class DistanceInt
  {
    public double dist;
    public int id;

    public DistanceInt(double _dist, int _id)
    {
      this.dist = _dist;
      this.id = _id;
    }

    public static int CompareByDistance(DistanceInt x, DistanceInt y)
    {
      if (x == null)
        return y == null ? 0 : -1;
      if (y == null)
        return 1;
      if (x.dist < y.dist)
        return -1;
      return x.dist > y.dist ? 1 : 0;
    }
  }
}
