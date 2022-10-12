using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Optrol.Theory;

namespace Optrol.Theory.Systems
{
    public class RungeKutta
    {
        static public double[] MovePoint(PointCollection pc, BuiltSystem system, double[] point, out double[] controlValue, double[] pars, double stepSize)
        {
            controlValue = pc.GetControlValue(system, point);

            double[] d1 = GetDerivative(pc, system, point, pars);
            double[] x2;
            MovePointInternal(system, point, pars, stepSize * 0.5, d1, out x2);

            double[] d2 = GetDerivative(pc, system, x2, pars);
            double[] x3;
            MovePointInternal(system, point, pars, stepSize * 0.5, d2, out x3);

            double[] d3 = GetDerivative(pc, system, x3, pars);
            double[] x4;
            MovePointInternal(system, point, pars, stepSize, d3, out x4);

            double[] d4 = GetDerivative(pc, system, x4, pars);

            double[] r = new double[system.GetDimension()];
            for(int i=0;i<r.Length;i++)
            {
                r[i] = point[i] + stepSize / 6.0 * (d1[i] + d2[i] * 2.0 + d3[i] * 2.0 + d4[i]);
            }

            return r;
        }

        private static void MovePointInternal(BuiltSystem system, double[] point, double[] pars, double stepSize, double[] der, out double[] numArray)
        {
            numArray = new double[point.Length];
            for (int index2 = 0; index2 < point.Length; ++index2)
                numArray[index2] = point[index2] + stepSize * der[index2];
        }

        private static double[] GetDerivative(PointCollection pc, BuiltSystem system, double[] point, double[] pars)
        {
            double[] controlValue = pc.GetControlValue(system, point);
            double[] derivative = new double[system.GetDimension()];
            system.GetDerivative(point, controlValue, pars, derivative);
            return derivative;
        }
    }
}
