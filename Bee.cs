using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch6Pg287_BeeManagementSystem2
{
    class Bee
    {
        public const double HoneyUnitsConsumedPerMg = .25;
        public double WeightMg { get; private set; }
        public Bee(double weightMg)
        {
            WeightMg = weightMg;
        }
        virtual public double HoneyConsumptiionRate()
        {
            return WeightMg * HoneyUnitsConsumedPerMg;
        }
    }
}
