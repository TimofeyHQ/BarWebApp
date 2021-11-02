using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarWebApp.Shared
{
    public class Bar
    {
        private Force leftConcentrated = new(true);
        private Force rightConcentrated = new(true);
        private Force distributed = new(false);
        public decimal Length;
        public decimal Area;
        public decimal Material;
        public Bar(decimal length, decimal area, decimal material) 
        {
            if (length > 0 && area > 0 && material > 0)
            {
                Length = length;
                Area = area;
                Material = material;
            }
            else throw new IndexOutOfRangeException("Incorrect characteristics for bar.");
        }
        public Force LeftConcentrated
        {
            get
            {
                return leftConcentrated;
            }
            set
            {
                if (value.IsConcentrated != true)
                    leftConcentrated = value;
            }
        }
        public Force RightConcentrated
        {
            get
            {
                return rightConcentrated;
            }
            set
            {
                if (value.IsConcentrated != true)
                    rightConcentrated = value;
            }
        }
        public Force Distributed
        {
            get
            {
                return distributed;
            }
            set
            {
                if (value.IsConcentrated != false && value.MomentScale == 0)
                    distributed = value;
            }
        }
        public override string ToString()
        {
            return $"{{{Length}, {Area}, {Material}, {Distributed}}}";
        }
    }
}
