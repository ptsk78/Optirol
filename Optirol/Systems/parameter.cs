namespace Optrol.Theory.Systems
{
  public class parameter
  {
    public double[] pars;
    public string name;

    public parameter(string txt)
    {
      string[] strArray = txt.Split(';');
      this.pars = new double[strArray.Length - 2];
      this.name = strArray[1];
      for (int index = 0; index < this.pars.Length; ++index)
        this.pars[index] = double.Parse(strArray[index + 2]);
    }
  }
}
