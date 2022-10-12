using System.Windows.Forms;

namespace Optrol.Theory.Systems
{
  public class optim
  {
    public equation eq;
    public int _line;

    public optim(string txt, int line)
    {
      this._line = line;
      string[] strArray = txt.Split(';');
      if (strArray.Length == 2)
      {
        this.eq = new equation(strArray[1]);
      }
      else
      {
        int num = (int) MessageBox.Show("Error in definition of optim " + txt + " on line " + (line + 1).ToString());
      }
    }
  }
}
