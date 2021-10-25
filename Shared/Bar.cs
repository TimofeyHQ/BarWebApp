using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarsWebApp.Shared
{
    public class Bar
    {
        private Force leftConcentrated;
        private Force rightConcentrated;
        private Force distributed;
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
                if (value.Type != Force.ForceType.q)
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
                if (value.Type != Force.ForceType.q)
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
                if (value.Type == Force.ForceType.q)
                    distributed = value;
            }
        }
    }
}
