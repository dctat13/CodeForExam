using IcelandTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcelandTest
{
    public static class ProductClassification
    {
        public static ProductType Classify(string label)
        {
            label = label.Trim().ToLower();

            switch(label)
            {
                case "aged brie":
                    return ProductType.AgedBrie;
                case "christmas crackers":
                    return ProductType.SeasonalItem;
                case "soap":
                    return ProductType.LongLastingItem;
                case "frozen item":
                    return ProductType.FrozenItem;
                case "fresh item":
                    return ProductType.FreshItem;
                default:
                    return ProductType.Unknown;
            }
        }
    }
}
