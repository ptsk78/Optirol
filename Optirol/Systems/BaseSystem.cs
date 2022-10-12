namespace Optrol.Theory.Systems
{
  public class BaseSystem
  {
    protected double[] mins;
    protected double[] maxs;
    protected int dimension;
    public int[] divPerDim;
    public double[] con_mins;
    public double[] con_maxs;
    protected int con_dimension;
    public int[] divPerDimCon;
    private int numAll;

    public double[] GetConMins()
    {
      return this.con_mins;
    }

    public double[] GetConMaxs()
    {
      return this.con_maxs;
    }

    public void SetAll()
    {
      this.numAll = 1;
      for (int index = 0; index < this.con_dimension; ++index)
        this.numAll *= this.divPerDimCon[index];
    }

    public int GetNumControls()
    {
      return this.numAll;
    }

    public void SetControl(int which, double[] con)
    {
      for (int index = 0; index < this.con_dimension; ++index)
      {
        con[index] = this.con_mins[index] + (double) (which % this.divPerDimCon[index]) * (this.con_maxs[index] - this.con_mins[index]) / ((double) this.divPerDimCon[index] - 1.0);
        which /= this.divPerDimCon[index];
      }
    }

    public int GetConDim()
    {
      return this.con_dimension;
    }

    public double[] GetMins()
    {
      return this.mins;
    }

    public double[] GetMaxs()
    {
      return this.maxs;
    }

    public int GetDimension()
    {
      return this.dimension;
    }

    public virtual void GetDerivative(
      double[] point,
      double[] control,
      double[] pars,
      double[] ret)
    {
    }
  }
}
