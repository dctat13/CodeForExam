using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcelandTest.Interfaces
{
    public enum ProductType { FreshItem, FrozenItem, LongLastingItem, SeasonalItem, Unknown, AgedBrie}


    public interface IProduct
    {

        string Label { get; set; }
        int SellIn { get; set; }
        int Quality { get; set; }

        ProductType ProductType { get; set; }
    }
}
