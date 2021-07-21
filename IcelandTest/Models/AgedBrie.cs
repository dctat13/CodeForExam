using IcelandTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcelandTest.Models
{
    public class AgedBrie : IProduct
    {
        public string Label { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
        public ProductType ProductType { get; set; }
    }
}
