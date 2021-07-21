using IcelandTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcelandTest.Processes
{
    public class FreshItemProcess : FrozenItemProcess
    {
        protected override void UpdateQuality(IProduct product)
        {
            base.UpdateQuality(product);
            base.UpdateQuality(product);
        }
    }
}
