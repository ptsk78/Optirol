using Optrol.Theory.Systems;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Optrol.Theory
{
    internal class Optimizer
    {
        private SortedDictionary<double, HashSet<int>> energyToPointsToOptimize;
        private Dictionary<int, double> pointsToEnergy;
        private PointCollection pc;
        private BuiltSystem system;
        private int lastPerc;
        private Optirol opt;
        private HashSet<int> allids;
        private int numall;

        public void Optimize(PointCollection _pc, BuiltSystem _system, Optirol _opt)
        {
            this.lastPerc = 0;
            this.allids = new HashSet<int>();
            this.numall = _pc.allPoints.Count;
            for (int index = 0; index < _pc.allPoints.Count; ++index)
                this.allids.Add(index);
            this.opt = _opt;
            this.opt.Invoke(this.opt.setPBDelegate, new object[] { 0 });
            this.pc = _pc;
            this.system = _system;
            this.energyToPointsToOptimize = new SortedDictionary<double, HashSet<int>>();
            this.pointsToEnergy = new Dictionary<int, double>();
            List<Point> zeroEnergyPoints = this.pc.GetZeroEnergyPoints(this.system);
            for (int index1 = 0; index1 < zeroEnergyPoints.Count; ++index1)
            {
                this.allids.Remove(zeroEnergyPoints[index1].id);
                for (int index2 = 0; index2 < zeroEnergyPoints[index1].neighbours.Count; ++index2)
                {
                    Point allPoint = this.pc.allPoints[zeroEnergyPoints[index1].neighbours[index2]];
                    if (allPoint.Energy == double.PositiveInfinity)
                        this.AddPointToOptimize(zeroEnergyPoints[index1], allPoint);
                }
            }
            this.OptimizeNextPublic();
            this.opt.Invoke(this.opt.WhenFinishedOptimizationDelegate);
        }

        public void OptimizeNextPublic()
        {
            while (this.energyToPointsToOptimize.Count != 0)
                this.OptimizeNext();
        }

        private void OptimizeNext()
        {
            SortedDictionary<double, HashSet<int>>.Enumerator enumerator = this.energyToPointsToOptimize.GetEnumerator();
            enumerator.MoveNext();
            double key1 = enumerator.Current.Key;
            int key2 = enumerator.Current.Value.First<int>();
            Point allPoint = this.pc.allPoints[key2];
            this.energyToPointsToOptimize[key1].Remove(key2);
            if (this.energyToPointsToOptimize[key1].Count == 0)
                this.energyToPointsToOptimize.Remove(key1);
            this.pointsToEnergy.Remove(key2);
            this.OptimizeNextInner(allPoint);
        }

        private void OptimizeNextInner(Point p)
        {
            if (!this.TryAllControlValues(p))
                return;
            if (this.allids.Contains(p.id))
            {
                this.allids.Remove(p.id);
                int num = 100 * (this.numall - this.allids.Count) / this.numall;
                if (num != this.lastPerc)
                {
                    this.opt.Invoke(this.opt.setPBDelegate, new object[] { num });
                    this.lastPerc = num;
                }
            }
            for (int index = 0; index < p.neighbours.Count; ++index)
            {
                Point allPoint = this.pc.allPoints[p.neighbours[index]];
                this.AddPointToOptimize(p, allPoint);
            }
        }

        private void AddPointToOptimize(Point p, Point q)
        {
            if (this.pointsToEnergy.ContainsKey(q.id))
            {
                if (this.pointsToEnergy[q.id] <= p.Energy)
                    return;
                this.energyToPointsToOptimize[this.pointsToEnergy[q.id]].Remove(q.id);
                if (this.energyToPointsToOptimize[this.pointsToEnergy[q.id]].Count == 0)
                    this.energyToPointsToOptimize.Remove(this.pointsToEnergy[q.id]);
                if (!this.energyToPointsToOptimize.ContainsKey(p.Energy))
                    this.energyToPointsToOptimize.Add(p.Energy, new HashSet<int>());
                this.energyToPointsToOptimize[p.Energy].Add(q.id);
                this.pointsToEnergy[q.id] = p.Energy;
            }
            else
            {
                this.pointsToEnergy.Add(q.id, p.Energy);
                if (!this.energyToPointsToOptimize.ContainsKey(p.Energy))
                    this.energyToPointsToOptimize.Add(p.Energy, new HashSet<int>());
                this.energyToPointsToOptimize[p.Energy].Add(q.id);
            }
        }

        private bool TryAllControlValues(Point p)
        {
            double num1 = double.PositiveInfinity;
            double[] numArray1 = (double[])null;
            double num2 = double.PositiveInfinity;
            double[] numArray2 = (double[])null;
            double[] positionFromId = this.pc.GetPositionFromId(p);
            bool flag1 = false;
            double[] numArray3 = new double[this.system.GetConDim()];
            double[] numArray4 = new double[this.system.GetDimension()];
            double num3 = double.PositiveInfinity;
            double num4 = double.PositiveInfinity;
            for (int which = 0; which < this.system.GetNumControls(); ++which)
            {
                this.system.SetControl(which, numArray3);
                double num5 = 0.0;
                bool flag2 = false;
                double num6 = 0.0;
                for (int i = 0; i < this.system.GetNumberOfParSets(); ++i)
                {
                    double[] parSet = this.system.GetParSet(i);
                    this.system.GetDerivative(positionFromId, numArray3, parSet, numArray4);
                    bool outside = false;
                    double error;
                    double energy = this.pc.GetEnergy(positionFromId, numArray3, parSet, numArray4, this.system, ref outside, out error);
                    num5 += error;
                    num6 += energy;
                    flag2 |= outside;
                }
                double num7 = num5 / (double)this.system.GetNumberOfParSets();
                double num8 = num6 / (double)this.system.GetNumberOfParSets();
                if (flag2)
                {
                    if (num8 < num2)
                    {
                        num2 = num8;
                        numArray2 = (double[])numArray3.Clone();
                        num4 = num7;
                    }
                }
                else
                {
                    flag1 = true;
                    if (num8 < num1)
                    {
                        num1 = num8;
                        numArray1 = (double[])numArray3.Clone();
                        num3 = num7;
                    }
                }
            }
            if (!flag1)
            {
                num1 = num2;
                numArray1 = numArray2;
                num3 = num4;
            }
            if (Constants.ingoreVeryMinorImprovements * p.Energy <= num1)
                return false;
            p.Energy = num1;
            p.optCon = numArray1;
            p.ErrorEstimation = num3;
            return true;
        }
    }
}
