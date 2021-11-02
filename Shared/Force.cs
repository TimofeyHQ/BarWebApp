using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarWebApp.Shared
{
    public class Force
    {
        public bool IsConcentrated { get;  set; }
        public decimal LinearScale { get; private set; } = 0;
        public decimal MomentScale { get; private set; } = 0;
        public Force(bool conc, decimal linSc, decimal momSc)
        {
            IsConcentrated = conc;
            LinearScale = linSc;
            MomentScale = momSc;
        }
        public Force(bool conc)
        {
            IsConcentrated = conc;
            LinearScale = 0;
            MomentScale = 0;
        }
        public Force Add(Force additional)
        {
            if (this.IsConcentrated == additional.IsConcentrated)
            {
                this.LinearScale += additional.LinearScale;
                this.MomentScale += additional.MomentScale;
                return this;
            }
            else
                return this;
        }
        public override string ToString()
        {
            if (IsConcentrated == true)
                return $"({LinearScale}, {MomentScale})";
            else
                return $"({LinearScale})";
        }
    }
}
