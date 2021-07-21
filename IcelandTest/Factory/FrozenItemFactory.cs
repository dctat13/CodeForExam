using IcelandTest.Interfaces;
using IcelandTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcelandTest.Factory
{
    public class FrozenItemFactory : IProductFactory
    {
        public IProduct Create(string label, int sellIn, int quality)
        {
            return new FrozenItem()
            {
                Label = label,
                SellIn = sellIn,
                Quality = quality,
                ProductType = ProductType.FrozenItem,
            };
        }
    }
}
