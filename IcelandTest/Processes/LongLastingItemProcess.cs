using IcelandTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcelandTest.Processes
{
    public class LongLastingItemProcess : ProductProcess
    {
        protected override void UpdateQuality(IProduct product)
        {
            //no degrading
        }

        protected override void UpdateSellIn(IProduct product)
        {
            //no limitation
        }
    }
}
