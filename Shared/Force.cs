using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarsWebApp.Shared
{
    public class Force
    {
        public enum ForceType
        {
            F, q, M
        };
        public ForceType Type { get; private set; }
        public decimal Scale { get; private set; }
    }
}
