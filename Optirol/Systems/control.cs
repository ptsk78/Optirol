using System.Windows.Forms;

namespace Optrol.Theory.Systems
{
  public class control
  {
    public double min;
    public double max;
    public int div;
    public string name;

    public control(string txt, int line)
    {
      string[] strArray = txt.Split(';');
      if (strArray.Length == 5)
      {
        this.name = strArray[1];
        this.min = double.Parse(strArray[2]);
        this.max = double.Parse(strArray[3]);
        this.div = int.Parse(strArray[4]);
      }
      else
      {
        int num = (int) MessageBox.Show("Error in definition of control " + txt + " on line " + (line + 1).ToString());
      }
    }
  }
}
