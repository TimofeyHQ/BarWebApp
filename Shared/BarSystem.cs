using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarWebApp.Shared;

namespace BarWebApp.Shared
{
    public class BarSystem
    {
        private List<Bar> bars = new();
        private List<Force> forces = new();
        public bool HasLeftBorder = false;
        public bool HasRightBorder = false;
        public Bar AddBar(decimal len, decimal area, decimal material)
        {
            if (len > 0 && area > 0 && material > 0)
            {
                var newBar = new Bar(len, area, material);
                if (HasLeftBorder && HasRightBorder == false)
                    HasLeftBorder = true;
                bars.Add(newBar);
                if (forces.Count == 0)
                    forces.Add(new Force(true));
                newBar.LeftConcentrated = forces.Last();
                newBar.Distributed = new Force(false);
                forces.Add(new Force(true));
                newBar.RightConcentrated = forces.Last();

                return newBar;
            }
            else return null;
        }
        public Force AddConcentratedForce(int node, Force conc)
        {
            if (node < forces.Count)
            {
                if (conc.IsConcentrated == true)
                {
                    var force = forces[node];
                    force.Add(conc);
                    return force;
                }
                else
                    throw new Exception("Incorrect force type.");
            }
            else
                throw new IndexOutOfRangeException("Incorrect Node Number.");
        }
        public Force AddDistributedForce(int bar, Force distr)
        {
            if (bar < bars.Count)
            {
                if (distr.IsConcentrated == false)
                {
                    var curDistr = bars[bar].Distributed;
                    curDistr.Add(distr);
                    return curDistr;
                }
                else
                    throw new Exception("Incorrect force type.");
            }
            else
                throw new IndexOutOfRangeException("Incorrect Bar Number.");
        }
        public void RemoveConcentratedForce(int node)
        {
            if (node < forces.Count)
            {
                Force current = forces[node], minus = new(true, -current.LinearScale, -current.MomentScale);
                AddConcentratedForce(node, minus);
            }
            else
                throw new IndexOutOfRangeException("Incorrect Node Number.");
        }
        public void RemoveDistributedForce(int bar)
        {
            if (bar < bars.Count)
            {
                Force current = bars[bar].Distributed, minus = new(false, -current.LinearScale, -current.MomentScale);
                AddDistributedForce(bar, minus);
            }
            else
                throw new IndexOutOfRangeException("Incorrect Bar Number.");
        }
        public void RemoveBar()
        {
            if (bars != null)
            {
                bars.Remove(bars.Last());
                forces.Remove(forces.Last());
            }
        }
        public override string ToString()
        {
            string result = new("");
            if (HasLeftBorder) result += "[";
            if (forces.Count != 0)
            {
                for (int i = 0; i < forces.Count - 1; i++)
                    result += $"{forces[i]}{bars[i]}";
                result += forces.Last();
            }
            if (HasRightBorder) result += "]";
            return result;
        }
        public (int, int) Size()
        {
            return (this.bars.Count, this.forces.Count);
        }
    }
}
