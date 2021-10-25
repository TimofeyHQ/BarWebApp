using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarsWebApp.Shared;

namespace BarWebApp.Shared
{
    class BarSystem
    {
        private List<Bar> bars;
        public bool HasLeftBorder = false;
        public bool HasRightBorder = false;
        public Bar AddtBar(decimal len, decimal area, decimal material)
        {
            if (len > 0 && area > 0 && material > 0)
            {
                var newBar = new Bar(len, area, material);
                if (HasLeftBorder && HasRightBorder == false)
                    HasLeftBorder = true;
                bars.Add(newBar);
                return newBar;
            }
            else return null;
        }
        public void RemoveLeftBar(string direction)
        {
            if (direction == "left")
                if (bars != null)
                    bars.Remove(bars.First());
            if (direction == "right")
                if (bars != null)
                    bars.Remove(bars.Last());
        }
    }
}
