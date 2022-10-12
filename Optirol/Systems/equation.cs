using System.Collections.Generic;
using System.Windows.Forms;

namespace Optrol.Theory.Systems
{
  public class equation
  {
    private string formula;
    private equation left;
    private equation right;
    private operation op;
    private string functionname;
    private int typeIndex;
    private Functions.functionOneArg func1;
    private Functions.functionTwoArgs func2;
    private double value;

    public string GetMatlabFunction(double[] pars)
    {
      switch (this.op)
      {
        case operation.plus:
          return "(" + this.left.GetMatlabFunction(pars) + "+" + this.right.GetMatlabFunction(pars) + ")";
        case operation.minus:
          return "(" + this.left.GetMatlabFunction(pars) + "-" + this.right.GetMatlabFunction(pars) + ")";
        case operation.multiply:
          return "(" + this.left.GetMatlabFunction(pars) + "*" + this.right.GetMatlabFunction(pars) + ")";
        case operation.divide:
          return "(" + this.left.GetMatlabFunction(pars) + "/" + this.right.GetMatlabFunction(pars) + ")";
        case operation.function:
          if (this.func1 != null)
            return this.functionname + "(" + this.left.GetMatlabFunction(pars) + ")";
          if (this.func2 != null)
            return this.functionname + "(" + this.left.GetMatlabFunction(pars) + "," + this.right.GetMatlabFunction(pars) + ")";
          break;
        case operation.variable:
          return "x(" + (this.typeIndex + 1).ToString() + ")";
        case operation.control:
          return "u(" + (this.typeIndex + 1).ToString() + ")";
        case operation.parameter:
          return pars[this.typeIndex].ToString();
        case operation.value:
          return this.value.ToString();
      }
      return "";
    }

    public double GetValue(double[] con, double[] var, double[] pars)
    {
      switch (this.op)
      {
        case operation.plus:
          return this.left.GetValue(con, var, pars) + this.right.GetValue(con, var, pars);
        case operation.minus:
          return this.left.GetValue(con, var, pars) - this.right.GetValue(con, var, pars);
        case operation.multiply:
          return this.left.GetValue(con, var, pars) * this.right.GetValue(con, var, pars);
        case operation.divide:
          return this.left.GetValue(con, var, pars) / this.right.GetValue(con, var, pars);
        case operation.function:
          if (this.func1 != null)
            return this.func1(this.left.GetValue(con, var, pars));
          if (this.func2 != null)
            return this.func2(this.left.GetValue(con, var, pars), this.right.GetValue(con, var, pars));
          break;
        case operation.variable:
          return var[this.typeIndex];
        case operation.control:
          return con[this.typeIndex];
        case operation.parameter:
          return pars[this.typeIndex];
        case operation.value:
          return this.value;
      }
      return 0.0;
    }

    public equation(string txt)
    {
      this.formula = txt;
    }

    public bool processEquation(
      List<control> controls,
      List<variable> variables,
      List<parameter> parameters,
      int line)
    {
      int position = 0;
      if (this.processOperand(new char[2]{ '+', '-' }, ref position))
      {
        this.left = new equation(this.formula.Substring(0, position));
        this.right = new equation(this.formula.Substring(position + 1));
        this.op = this.formula[position] != '+' ? operation.minus : operation.plus;
        if (this.op == operation.minus && position == 0)
        {
          this.left = new equation("");
          this.left.op = operation.value;
          this.left.value = 0.0;
        }
        else if (!this.left.processEquation(controls, variables, parameters, line))
          return false;
        return this.right.processEquation(controls, variables, parameters, line);
      }
      if (this.processOperand(new char[2]{ '*', '/' }, ref position))
      {
        this.left = new equation(this.formula.Substring(0, position));
        this.right = new equation(this.formula.Substring(position + 1));
        this.op = this.formula[position] != '*' ? operation.divide : operation.multiply;
        return this.left.processEquation(controls, variables, parameters, line) && this.right.processEquation(controls, variables, parameters, line);
      }
      if (this.formula.StartsWith("(") && this.formula.EndsWith(")"))
      {
        this.formula = this.formula.Substring(1, this.formula.Length - 2);
        return this.processEquation(controls, variables, parameters, line);
      }
      position = this.formula.IndexOf('(');
      if (position != -1 && this.formula.EndsWith(")"))
      {
        string str = this.formula.Substring(position + 1, this.formula.Length - 2 - position);
        string[] strArray = str.Split(',');
        if (strArray.Length == 0 && strArray.Length > 2)
        {
          int num = (int) MessageBox.Show("Function does not exist. [" + str + "] on line " + (line + 1).ToString());
          return false;
        }
        this.left = new equation(strArray[0]);
        if (!this.left.processEquation(controls, variables, parameters, line))
          return false;
        this.functionname = this.formula.Substring(0, position);
        if (strArray.Length == 1)
        {
          this.func1 = (Functions.functionOneArg) Functions.GetFunctionNumber(this.functionname, strArray.Length);
        }
        else
        {
          this.right = new equation(strArray[1]);
          if (!this.right.processEquation(controls, variables, parameters, line))
            return false;
          this.func2 = (Functions.functionTwoArgs) Functions.GetFunctionNumber(this.functionname, strArray.Length);
        }
        if (this.functionname.CompareTo("ln") == 0)
          this.functionname = "log";
        if (this.functionname.CompareTo("log") == 0)
          this.functionname = "log10";
        if (this.functionname.CompareTo("pow") == 0)
          this.functionname = "power";
        this.op = operation.function;
        return true;
      }
      for (int index = 0; index < controls.Count; ++index)
      {
        if (controls[index].name.CompareTo(this.formula) == 0)
        {
          this.op = operation.control;
          this.typeIndex = index;
          return true;
        }
      }
      for (int index = 0; index < variables.Count; ++index)
      {
        if (variables[index].name.CompareTo(this.formula) == 0)
        {
          this.op = operation.variable;
          this.typeIndex = index;
          return true;
        }
      }
      for (int index = 0; index < parameters.Count; ++index)
      {
        if (parameters[index].name.CompareTo(this.formula) == 0)
        {
          this.op = operation.parameter;
          this.typeIndex = index;
          return true;
        }
      }
      if (double.TryParse(this.formula, out this.value))
      {
        this.op = operation.value;
        return true;
      }
      int num1 = (int) MessageBox.Show("Error [" + this.formula + "] on line " + (line + 1).ToString());
      return false;
    }

    private bool processOperand(char[] operands, ref int position)
    {
      position = this.formula.Length - 1;
      int num = 0;
      while (position >= 0)
      {
        if (num == 0)
        {
          for (int index = 0; index < operands.Length; ++index)
          {
            if ((int) this.formula[position] == (int) operands[index])
              return true;
          }
        }
        if (this.formula[position] == ')')
          ++num;
        if (this.formula[position] == '(')
          --num;
        --position;
      }
      return false;
    }
  }
}
