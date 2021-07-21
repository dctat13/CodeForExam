using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcelandTest.Interfaces
{
    public interface IProductFactory
    {
        IProduct Create(string label, int sellIn, int quality);
    }
}
