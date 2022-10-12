using Optrol.Theory.Systems;
using SharpGL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Optrol.Theory.Systems
{
  public class PointCollection
  {
    private double[] mins;
    private double[] maxs;
    private int dimension;
    private int[] divPerDim;
    public List<Point> allPoints;
    public static double maxValue;

    public void SaveToFile(string file)
    {
      BinaryWriter binaryWriter = new BinaryWriter((Stream) File.Open(file, FileMode.Create));
      binaryWriter.Write(this.dimension);
      binaryWriter.Write(this.allPoints[0].optCon.Length);
      for (int index = 0; index < this.dimension; ++index)
      {
        binaryWriter.Write(this.mins[index]);
        binaryWriter.Write(this.maxs[index]);
        binaryWriter.Write(this.divPerDim[index]);
      }
      for (int index1 = 0; index1 < this.allPoints.Count; ++index1)
      {
        Point allPoint = this.allPoints[index1];
        binaryWriter.Write(allPoint.Energy);
        binaryWriter.Write(allPoint.ErrorEstimation);
        for (int index2 = 0; index2 < allPoint.optCon.Length; ++index2)
          binaryWriter.Write(allPoint.optCon[index2]);
      }
      binaryWriter.Close();
    }

    private Point GetPoint(int v1, int v2, int[] others, int i1, int i2)
    {
      int index1 = 0;
      for (int index2 = this.dimension - 1; index2 >= 0; --index2)
      {
        int num = index1 * this.divPerDim[index2];
        index1 = index2 != v1 ? (index2 != v2 ? num + others[index2] : num + i2) : num + i1;
      }
      return this.allPoints[index1];
    }

    public void DoDraw(
      int v1,
      int v2,
      int[] others,
      OpenGL gl,
      bool energy,
      float rotHor,
      float rotVer,
      BuiltSystem system,
      int whichCont)
    {
      double[] conMins = system.GetConMins();
      double[] conMaxs = system.GetConMaxs();
      gl.Clear(16640U);
      gl.LoadIdentity();
      gl.Translate(0.0f, 0.0f, -5f);
      gl.Rotate((double) rotVer - 90.0, 1.0, 0.0, 0.0);
      gl.Rotate(-rotHor, 0.0f, 0.0f, 1f);
      gl.Enable(3042U);
      gl.BlendFunc(770U, 771U);
      if ((double) rotHor < 0.0)
      {
        for (int i1 = this.divPerDim[v1] - 2; i1 >= 0; --i1)
        {
          for (int i2 = 0; i2 < this.divPerDim[v2] - 1; ++i2)
            this.DoQuad(v1, v2, others, gl, energy, conMins, conMaxs, i1, i2, whichCont);
        }
      }
      else
      {
        for (int i1 = 0; i1 < this.divPerDim[v1] - 1; ++i1)
        {
          for (int i2 = 0; i2 < this.divPerDim[v2] - 1; ++i2)
            this.DoQuad(v1, v2, others, gl, energy, conMins, conMaxs, i1, i2, whichCont);
        }
      }
    }

    private void DoQuad(
      int v1,
      int v2,
      int[] others,
      OpenGL gl,
      bool energy,
      double[] con_mins,
      double[] con_maxs,
      int i1,
      int i2,
      int whichCont)
    {
      double x1 = 4.0 * (double) i1 / ((double) this.divPerDim[v1] - 1.0) - 2.0;
      double x2 = 4.0 * ((double) i1 + 1.0) / ((double) this.divPerDim[v1] - 1.0) - 2.0;
      double y1 = 4.0 * (double) i2 / ((double) this.divPerDim[v2] - 1.0) - 2.0;
      double y2 = 4.0 * ((double) i2 + 1.0) / ((double) this.divPerDim[v2] - 1.0) - 2.0;
      Point point1 = this.GetPoint(v1, v2, others, i1, i2);
      Point point2 = this.GetPoint(v1, v2, others, i1 + 1, i2);
      Point point3 = this.GetPoint(v1, v2, others, i1 + 1, i2 + 1);
      Point point4 = this.GetPoint(v1, v2, others, i1, i2 + 1);
      float red1 = 0.0f;
      float red2 = 0.0f;
      float red3 = 0.0f;
      float red4 = 0.0f;
      bool flag = true;
      if (energy)
      {
        if (point1.Energy == double.PositiveInfinity || point2.Energy == double.PositiveInfinity || (point3.Energy == double.PositiveInfinity || point4.Energy == double.PositiveInfinity))
        {
          flag = false;
        }
        else
        {
          red1 = (float) (point1.Energy / PointCollection.maxValue);
          red2 = (float) (point2.Energy / PointCollection.maxValue);
          red3 = (float) (point3.Energy / PointCollection.maxValue);
          red4 = (float) (point4.Energy / PointCollection.maxValue);
        }
      }
      else if (point1.optCon == null || point2.optCon == null || (point3.optCon == null || point4.optCon == null))
      {
        flag = false;
      }
      else
      {
        red1 = (float) ((point1.optCon[whichCont] - con_mins[whichCont]) / (con_maxs[whichCont] - con_mins[whichCont]));
        red2 = (float) ((point2.optCon[whichCont] - con_mins[whichCont]) / (con_maxs[whichCont] - con_mins[whichCont]));
        red3 = (float) ((point3.optCon[whichCont] - con_mins[whichCont]) / (con_maxs[whichCont] - con_mins[whichCont]));
        red4 = (float) ((point4.optCon[whichCont] - con_mins[whichCont]) / (con_maxs[whichCont] - con_mins[whichCont]));
      }
      if (!flag)
        return;
      gl.Begin(7U);
      gl.Color(red1, 0.0f, 1f - red1, 0.8f);
      gl.Vertex(x1, y1, ((double) red1 - 0.5) * 2.0);
      gl.Color(red2, 0.0f, 1f - red2, 0.8f);
      gl.Vertex(x2, y1, ((double) red2 - 0.5) * 2.0);
      gl.Color(red3, 0.0f, 1f - red3, 0.8f);
      gl.Vertex(x2, y2, ((double) red3 - 0.5) * 2.0);
      gl.Color(red4, 0.0f, 1f - red4, 0.8f);
      gl.Vertex(x1, y2, ((double) red4 - 0.5) * 2.0);
      gl.End();
      gl.Begin(1U);
      gl.Color(0.0f, 0.5f, 0.1f, 0.6f);
      gl.Vertex(x1, y1, ((double) red1 - 0.5) * 2.0);
      gl.Vertex(x2, y1, ((double) red2 - 0.5) * 2.0);
      gl.Vertex(x2, y1, ((double) red2 - 0.5) * 2.0);
      gl.Vertex(x2, y2, ((double) red3 - 0.5) * 2.0);
      gl.Vertex(x2, y2, ((double) red3 - 0.5) * 2.0);
      gl.Vertex(x1, y2, ((double) red4 - 0.5) * 2.0);
      gl.Vertex(x1, y2, ((double) red4 - 0.5) * 2.0);
      gl.Vertex(x1, y2, ((double) red4 - 0.5) * 2.0);
      gl.End();
    }

    public void FillOutTable(
      int v1,
      int v2,
      int[] others,
      DataGridView dataGridViewE,
      DataGridView dataGridViewC,
      int whichControl,
      DataGridView dataGridViewError)
    {
      dataGridViewC.Columns.Clear();
      dataGridViewC.Rows.Clear();
      dataGridViewE.Columns.Clear();
      dataGridViewE.Rows.Clear();
      dataGridViewError.Columns.Clear();
      dataGridViewError.Rows.Clear();
      for (int index = 0; index < this.divPerDim[v1]; ++index)
      {
        dataGridViewE.Columns.Add(index.ToString(), index.ToString());
        dataGridViewC.Columns.Add(index.ToString(), index.ToString());
        dataGridViewError.Columns.Add(index.ToString(), index.ToString());
      }
      dataGridViewE.Rows.Add(this.divPerDim[v2]);
      dataGridViewC.Rows.Add(this.divPerDim[v2]);
      dataGridViewError.Rows.Add(this.divPerDim[v2]);
      for (int index1 = 0; index1 < this.divPerDim[v1]; ++index1)
      {
        for (int index2 = 0; index2 < this.divPerDim[v2]; ++index2)
        {
          int index3 = 0;
          for (int index4 = this.dimension - 1; index4 >= 0; --index4)
          {
            int num = index3 * this.divPerDim[index4];
            index3 = index4 != v1 ? (index4 != v2 ? num + others[index4] : num + index2) : num + index1;
          }
          dataGridViewC[index1, index2].Value = (object) (this.allPoints[index3].optCon == null ? double.NaN : this.allPoints[index3].optCon[whichControl]);
          dataGridViewE[index1, index2].Value = (object) this.allPoints[index3].Energy;
          dataGridViewError[index1, index2].Value = (object) this.allPoints[index3].ErrorEstimation;
        }
      }
    }

    public PointCollection(BuiltSystem bs)
    {
      this.divPerDim = bs.divPerDim;
      this.mins = bs.GetMins();
      this.maxs = bs.GetMaxs();
      this.dimension = bs.GetDimension();
      int num = 1;
      for (int index = 0; index < this.dimension; ++index)
        num *= bs.divPerDim[index];
      this.allPoints = new List<Point>();
      for (int _id = 0; _id < num; ++_id)
        this.allPoints.Add(new Point(_id));
      for (int index = 0; index < this.allPoints.Count; ++index)
        this.allPoints[index].neighbours = this.GetSurroundingPoints(this.allPoints[index]);
    }

    public double[] GetPositionFromId(Point p)
    {
      return this.GetPositionFromId(p.id);
    }

    public double[] GetPositionFromId(int id)
    {
      double[] numArray = new double[this.dimension];
      for (int index = 0; index < this.dimension; ++index)
      {
        numArray[index] = this.mins[index] + (this.maxs[index] - this.mins[index]) * (double) (id % this.divPerDim[index]) / ((double) this.divPerDim[index] - 1.0);
        id /= this.divPerDim[index];
      }
      return numArray;
    }

    private int[] GetPositionFromIdInt(int id)
    {
      int[] numArray = new int[this.dimension];
      for (int index = 0; index < this.dimension; ++index)
      {
        numArray[index] = id % this.divPerDim[index];
        id /= this.divPerDim[index];
      }
      return numArray;
    }

    public List<Point> GetZeroEnergyPoints(BuiltSystem system)
    {
      List<Point> ret = new List<Point>();
      List<DistanceInt>[] closestToOrigin = new List<DistanceInt>[this.dimension];
      for (int index = 0; index < this.dimension; ++index)
      {
        closestToOrigin[index] = new List<DistanceInt>();
        for (int _id = 0; _id < this.divPerDim[index]; ++_id)
        {
          if (!system.variables[index].anything)
            closestToOrigin[index].Add(new DistanceInt(Math.Abs(this.mins[index] + (this.maxs[index] - this.mins[index]) * (double) _id / ((double) this.divPerDim[index] - 1.0) - system.variables[index].controlTo), _id));
          else
            closestToOrigin[index].Add(new DistanceInt(0.0, _id));
        }
        closestToOrigin[index].Sort(new Comparison<DistanceInt>(DistanceInt.CompareByDistance));
        if (!system.variables[index].anything)
        {
          while (closestToOrigin[index].Count > 2)
            closestToOrigin[index].RemoveAt(2);
        }
      }
      this.AddAllPointsZeroEnergy(closestToOrigin, (int[]) null, 0, ret, system);
      return ret;
    }

    private bool IsConvergingToZero(Point p, BuiltSystem bs)
    {
      double[] numArray = new double[bs.GetConDim()];
      double[] positionFromId = this.GetPositionFromId(p);
      double[] ret = new double[bs.GetDimension()];
      bool flag = false;
      for (int which = 0; which < bs.GetNumControls(); ++which)
      {
        bs.SetControl(which, numArray);
        double num1 = 0.0;
        for (int i = 0; i < bs.GetNumberOfParSets(); ++i)
        {
          bs.GetDerivative(positionFromId, numArray, bs.GetParSet(i), ret);
          double num2 = 0.0;
          double num3 = 0.0;
          for (int index = 0; index < bs.GetDimension(); ++index)
          {
            if (!bs.variables[index].anything)
            {
              num2 += (positionFromId[index] - bs.variables[index].controlTo) * ret[index];
              num3 += ret[index] * ret[index];
            }
          }
          double num4 = -num2 / num3;
          if (num4 > 0.0 && num3 != 0.0)
            num1 += num4 * bs.opt.eq.GetValue(numArray, positionFromId, bs.GetParSet(i));
          else
            num1 += double.PositiveInfinity;
        }
        double num5 = num1 / (double) bs.GetNumberOfParSets();
        if (num5 < p.Energy)
        {
          p.Energy = num5;
          p.ErrorEstimation = 0.0;
          p.optCon = (double[]) numArray.Clone();
          flag = true;
        }
      }
      return flag;
    }

    private void AddAllPointsZeroEnergy(
      List<DistanceInt>[] closestToOrigin,
      int[] tmp,
      int where,
      List<Point> ret,
      BuiltSystem system)
    {
      if (where == this.dimension)
      {
        int index1 = 0;
        for (int index2 = this.dimension - 1; index2 >= 0; --index2)
          index1 = index1 * this.divPerDim[index2] + tmp[index2];
        if (!this.IsConvergingToZero(this.allPoints[index1], system))
          return;
        ret.Add(this.allPoints[index1]);
      }
      else
      {
        int[] tmp1 = new int[where + 1];
        for (int index = 0; index < where; ++index)
          tmp1[index] = tmp[index];
        for (int index = 0; index < closestToOrigin[where].Count; ++index)
        {
          tmp1[where] = closestToOrigin[where][index].id;
          this.AddAllPointsZeroEnergy(closestToOrigin, tmp1, where + 1, ret, system);
        }
      }
    }

    private List<int> GetSurroundingPoints(Point p)
    {
      List<int> ret = new List<int>();
      this.AddAllPSurroundingPoints(this.GetPositionFromIdInt(p.id), (int[]) null, 0, ret, p);
      return ret;
    }

    private void AddAllPSurroundingPoints(
      int[] pos,
      int[] tmp,
      int where,
      List<int> ret,
      Point p)
    {
      if (where == this.dimension)
      {
        int num = 0;
        for (int index = this.dimension - 1; index >= 0; --index)
          num = num * this.divPerDim[index] + tmp[index];
        ret.Add(num);
      }
      else
      {
        int[] tmp1 = new int[where + 1];
        for (int index = 0; index < where; ++index)
          tmp1[index] = tmp[index];
        if (pos[where] - 1 >= 0)
        {
          tmp1[where] = pos[where] - 1;
          this.AddAllPSurroundingPoints(pos, tmp1, where + 1, ret, p);
        }
        tmp1[where] = pos[where];
        this.AddAllPSurroundingPoints(pos, tmp1, where + 1, ret, p);
        if (pos[where] + 1 >= this.divPerDim[where])
          return;
        tmp1[where] = pos[where] + 1;
        this.AddAllPSurroundingPoints(pos, tmp1, where + 1, ret, p);
      }
    }

    public double GetEnergy(
      double[] point,
      double[] control,
      double[] pars,
      double[] direction,
      BuiltSystem system,
      ref bool outside,
      out double error)
    {
      return this.GetEnergyInner(point, control, pars, direction, system, ref outside, out error);
    }

    private double GetEnergyInner(
      double[] point,
      double[] control,
      double[] pars,
      double[] direction,
      BuiltSystem system,
      ref bool outside,
      out double error)
    {
      error = 0.0;
      double time = double.MaxValue;
      int index1 = -1;
      for (int index2 = 0; index2 < this.dimension; ++index2)
      {
        double num = Math.Abs((this.maxs[index2] - this.mins[index2]) / ((double) this.divPerDim[index2] - 1.0) / direction[index2]);
        if (time > num)
        {
          time = num;
          index1 = index2;
        }
      }
      if (index1 == -1)
        return double.PositiveInfinity;
      double[] numArray1 = new double[this.dimension];
      for (int index2 = 0; index2 < this.dimension; ++index2)
        numArray1[index2] = point[index2] + time * direction[index2];
      double[] numArray2 = new double[this.dimension];
      system.GetDerivative(numArray1, control, pars, numArray2);
      double num1 = Math.Abs((this.maxs[index1] - this.mins[index1]) / ((double) this.divPerDim[index1] - 1.0) / numArray2[index1]);
      double num2 = system.opt.eq.GetValue(control, point, pars);
      double num3 = system.opt.eq.GetValue(control, numArray1, pars);
      error += Math.Abs(time - num1) * num2;
      error += Math.Abs(num2 - num3) * time;
      double error1;
      double energy = this.GetEnergy(numArray1, ref outside, time, direction, numArray2, out error1, error);
      error += error1;
      return energy + time * num2;
    }

    private double GetEnergy(
      double[] p,
      ref bool outside,
      double time,
      double[] d1,
      double[] d2,
      out double error,
      double t_error)
    {
      double[] pp = new double[this.dimension];
      double[] dd = new double[this.dimension];
      for (int index = 0; index < this.dimension; ++index)
      {
        pp[index] = (p[index] - this.mins[index]) / (this.maxs[index] - this.mins[index]) * ((double) this.divPerDim[index] - 1.0);
        dd[index] = Math.Abs((d1[index] - d2[index]) * time / (this.maxs[index] - this.mins[index]) * ((double) this.divPerDim[index] - 1.0));
      }
      return this.GetEnergy(pp, 0, ref outside, dd, out error);
    }

    private double GetEnergy(
      double[] pp,
      int where,
      ref bool outside,
      double[] dd,
      out double error)
    {
      double num1 = 0.0;
      if (where == this.dimension)
      {
        error = 0.0;
        return this.ApproximateEnergy(pp, ref outside, out error);
      }
      if (Math.Abs(pp[where] - Math.Round(pp[where])) < Constants.maxDif)
      {
        pp[where] = Math.Round(pp[where]);
        return this.GetEnergy(pp, where + 1, ref outside, dd, out error);
      }
      double[] pp1 = (double[]) pp.Clone();
      double[] pp2 = (double[]) pp.Clone();
      pp1[where] = Math.Floor(pp[where]);
      pp2[where] = Math.Ceiling(pp[where]);
      double error1;
      double energy1 = this.GetEnergy(pp1, where + 1, ref outside, dd, out error1);
      double error2;
      double energy2 = this.GetEnergy(pp2, where + 1, ref outside, dd, out error2);
      double num2 = num1 + (1.0 - pp[where] + Math.Floor(pp[where])) * energy1 + (1.0 - Math.Ceiling(pp[where]) + pp[where]) * energy2;
      error = 0.0;
      error += Math.Abs((energy1 - energy2) * dd[where]);
      error += (1.0 - pp[where] + Math.Floor(pp[where])) * error1;
      error += (1.0 - Math.Ceiling(pp[where]) + pp[where]) * error2;
      return num2;
    }

    private double ApproximateEnergy(double[] pp, ref bool outside, out double error)
    {
      return this.ApproximateEnergyInner(0, pp, ref outside, out error);
    }

    private double ApproximateEnergyInner(
      int where,
      double[] pp,
      ref bool outside,
      out double error)
    {
      if (where == this.dimension)
      {
        int index1 = 0;
        for (int index2 = 0; index2 < this.dimension; ++index2)
          index1 = index1 * this.divPerDim[this.dimension - 1 - index2] + (int) pp[this.dimension - 1 - index2];
        error = this.allPoints[index1].ErrorEstimation;
        return this.allPoints[index1].Energy;
      }
      if (pp[where] < -1.0 || pp[where] > (double) this.divPerDim[where])
      {
        outside = true;
        error = double.PositiveInfinity;
        return double.PositiveInfinity;
      }
      if (pp[where] < 0.0)
      {
        outside = true;
        double num1 = pp[where];
        pp[where] = 0.0;
        double error1;
        double num2 = this.ApproximateEnergyInner(where + 1, pp, ref outside, out error1);
        pp[where] = 1.0;
        double error2;
        double num3 = this.ApproximateEnergyInner(where + 1, pp, ref outside, out error2);
        pp[where] = num1;
        error = error1 + Math.Abs(pp[where] * (error1 - error2));
        return num2 != double.PositiveInfinity && num3 != double.PositiveInfinity ? num2 + Math.Abs(pp[where] * (num2 - num3)) : double.PositiveInfinity;
      }
      if (pp[where] <= (double) this.divPerDim[where] - 1.0)
        return this.ApproximateEnergyInner(where + 1, pp, ref outside, out error);
      outside = true;
      double num4 = pp[where];
      pp[where] = (double) (this.divPerDim[where] - 1);
      double error3;
      double num5 = this.ApproximateEnergyInner(where + 1, pp, ref outside, out error3);
      pp[where] = (double) (this.divPerDim[where] - 2);
      double error4;
      double num6 = this.ApproximateEnergyInner(where + 1, pp, ref outside, out error4);
      pp[where] = num4;
      error = error3 + Math.Abs((pp[where] - (double) this.divPerDim[where] + 1.0) * (error3 - error4));
      return num5 != double.PositiveInfinity && num6 != double.PositiveInfinity ? num5 + Math.Abs((pp[where] - (double) this.divPerDim[where] + 1.0) * (num5 - num6)) : double.PositiveInfinity;
    }

    public double[] GetControlValue(BuiltSystem bs, double[] point)
    {
      return this.GetControlValueInternal((int[]) null, point);
    }

    private double[] GetControlValueInternal(int[] where, double[] point)
    {
      if (where != null && where.Length == point.Length)
      {
        int index1 = 0;
        for (int index2 = 0; index2 < where.Length; ++index2)
          index1 = index1 * this.divPerDim[where.Length - 1 - index2] + where[where.Length - 1 - index2];
        return this.allPoints[index1].optCon;
      }
      int[] where1 = new int[where == null ? 1 : where.Length + 1];
      for (int index = 0; index < where1.Length - 1; ++index)
        where1[index] = where[index];
      double a = (point[where1.Length - 1] - this.mins[where1.Length - 1]) / (this.maxs[where1.Length - 1] - this.mins[where1.Length - 1]) * ((double) this.divPerDim[where1.Length - 1] - 1.0);
      if (a < 0.0)
        a = 0.0;
      if (a > (double) this.divPerDim[where1.Length - 1] - 1.0)
        a = (double) this.divPerDim[where1.Length - 1] - 1.0;
      where1[where1.Length - 1] = (int) Math.Round(a);
      return this.GetControlValueInternal(where1, point);
    }
  }
}
