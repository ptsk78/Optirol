using System;
using System.Collections.Generic;

namespace Optrol.Theory.Systems
{
  internal class Functions
  {
    public static Dictionary<string, Functions.functionOneArg> function1;
    public static Dictionary<string, Functions.functionTwoArgs> function2;

    private static double sign(double num)
    {
      return (double) Math.Sign(num);
    }

    private static void Initialize()
    {
      Functions.function1 = new Dictionary<string, Functions.functionOneArg>();
      Functions.function2 = new Dictionary<string, Functions.functionTwoArgs>();
      Functions.function1.Add("acos", new Functions.functionOneArg(Math.Acos));
      Functions.function1.Add("asin", new Functions.functionOneArg(Math.Asin));
      Functions.function1.Add("atan", new Functions.functionOneArg(Math.Atan));
      Functions.function1.Add("cos", new Functions.functionOneArg(Math.Cos));
      Functions.function1.Add("cosh", new Functions.functionOneArg(Math.Cosh));
      Functions.function1.Add("sin", new Functions.functionOneArg(Math.Sin));
      Functions.function1.Add("sinh", new Functions.functionOneArg(Math.Sinh));
      Functions.function1.Add("tan", new Functions.functionOneArg(Math.Tan));
      Functions.function1.Add("tanh", new Functions.functionOneArg(Math.Tanh));
      Functions.function1.Add("exp", new Functions.functionOneArg(Math.Exp));
      Functions.function1.Add("ln", new Functions.functionOneArg(Math.Log));
      Functions.function1.Add("log", new Functions.functionOneArg(Math.Log10));
      Functions.function1.Add("sqrt", new Functions.functionOneArg(Math.Sqrt));
      Functions.function2.Add("pow", new Functions.functionTwoArgs(Math.Pow));
      Functions.function1.Add("abs", new Functions.functionOneArg(Math.Abs));
      Functions.function1.Add("round", new Functions.functionOneArg(Math.Round));
      Functions.function1.Add("floor", new Functions.functionOneArg(Math.Floor));
      Functions.function1.Add("ceiling", new Functions.functionOneArg(Math.Ceiling));
      Functions.function1.Add("sign", new Functions.functionOneArg(Functions.sign));
      Functions.function2.Add("min", new Functions.functionTwoArgs(Math.Min));
      Functions.function2.Add("max", new Functions.functionTwoArgs(Math.Max));
    }

    public static object GetFunctionNumber(string name, int numOfArgs)
    {
      if (Functions.function1 == null)
        Functions.Initialize();
      switch (numOfArgs)
      {
        case 1:
          if (Functions.function1.ContainsKey(name))
            return (object) Functions.function1[name];
          break;
        case 2:
          if (Functions.function2.ContainsKey(name))
            return (object) Functions.function2[name];
          break;
      }
      return (object) null;
    }

    public delegate double functionOneArg(double num);

    public delegate double functionTwoArgs(double num1, double num2);
  }
}
