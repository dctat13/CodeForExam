using IcelandTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcelandTest.Processes
{
    public class AgedBrieProcess : ProductProcess
    {
        protected override void UpdateQuality(IProduct product)
        {
            product.Quality += 1;
        }
    }
}
