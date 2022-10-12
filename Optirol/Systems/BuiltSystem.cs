using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Optrol.Theory.Systems
{
  public class BuiltSystem : BaseSystem
  {
    private List<control> controls;
    public List<variable> variables;
    private List<parameter> parameters;
    public optim opt;
    private double[][] pars;

    public int GetNumberOfParSets()
    {
      return this.pars == null ? 1 : this.pars.Length;
    }

    public double[] GetParSet(int i)
    {
      return this.pars == null ? (double[]) null : this.pars[i];
    }

    private void SetPars()
    {
      if (this.parameters.Count == 0)
      {
        this.pars = (double[][]) null;
      }
      else
      {
        this.pars = new double[this.parameters[0].pars.Length][];
        for (int index1 = 0; index1 < this.parameters[0].pars.Length; ++index1)
        {
          this.pars[index1] = new double[this.parameters.Count];
          for (int index2 = 0; index2 < this.pars[index1].Length; ++index2)
            this.pars[index1][index2] = this.parameters[index2].pars[index1];
        }
      }
    }

    public BuiltSystem()
    {
      this.opt = new optim("optim;1", -1);
    }

    public string GetName(operation op, int num)
    {
      if (op == operation.variable)
        return this.variables[num].name;
      return op == operation.control ? this.controls[num].name : "";
    }

    public bool Process(string text)
    {
      try
      {
        this.controls = new List<control>();
        this.variables = new List<variable>();
        this.parameters = new List<parameter>();
        text = text.Replace(" ", "");
        string[] strArray = text.Split('\n');
        for (int line = 0; line < strArray.Length; ++line)
        {
          try
          {
            if (strArray[line].Length != 0)
            {
              if (strArray[line].StartsWith("optim;"))
                this.opt = new optim(strArray[line], line);
              else if (strArray[line].StartsWith("control;"))
                this.controls.Add(new control(strArray[line], line));
              else if (strArray[line].StartsWith("variable;"))
                this.variables.Add(new variable(strArray[line], line)
                {
                  line = line
                });
              else if (strArray[line].StartsWith("parameter;"))
              {
                this.parameters.Add(new parameter(strArray[line]));
                if (this.parameters.Count > 1)
                {
                  if (this.parameters[this.parameters.Count - 1].pars.Length != this.parameters[this.parameters.Count - 2].pars.Length)
                  {
                    int num = (int) MessageBox.Show("All parameters must have same dimension on line " + (line + 1).ToString());
                    return false;
                  }
                }
              }
              else
              {
                int num = (int) MessageBox.Show("Type not defined on line " + (line + 1).ToString());
                return false;
              }
            }
          }
          catch
          {
            int num = (int) MessageBox.Show("Error on line " + (line + 1).ToString());
          }
        }
        for (int index = 0; index < this.variables.Count; ++index)
        {
          if (!this.variables[index].eq.processEquation(this.controls, this.variables, this.parameters, this.variables[index].line))
            return false;
        }
        this.opt.eq.processEquation(this.controls, this.variables, this.parameters, this.opt._line);
        this.dimension = this.variables.Count;
        this.con_dimension = this.controls.Count;
        this.mins = new double[this.dimension];
        this.maxs = new double[this.dimension];
        this.con_mins = new double[this.con_dimension];
        this.con_maxs = new double[this.con_dimension];
        this.divPerDim = new int[this.dimension];
        this.divPerDimCon = new int[this.con_dimension];
        for (int index = 0; index < this.dimension; ++index)
        {
          this.mins[index] = this.variables[index].min;
          this.maxs[index] = this.variables[index].max;
          this.divPerDim[index] = this.variables[index].div;
        }
        for (int index = 0; index < this.con_dimension; ++index)
        {
          this.con_mins[index] = this.controls[index].min;
          this.con_maxs[index] = this.controls[index].max;
          this.divPerDimCon[index] = this.controls[index].div;
        }
        this.SetPars();
        this.SetAll();
        if (this.controls.Count != 0 && this.variables.Count != 0)
          return true;
        int num1 = (int) MessageBox.Show("No controls or variables");
        return false;
      }
      catch
      {
        return false;
      }
    }

    public override void GetDerivative(
      double[] point,
      double[] control,
      double[] pars,
      double[] ret)
    {
      for (int index = 0; index < this.dimension; ++index)
        ret[index] = this.variables[index].eq.GetValue(control, point, pars);
    }
  }
}
