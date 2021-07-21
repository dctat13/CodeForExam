using IcelandTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcelandTest.Processes
{
    public abstract class ProductProcess : IProductProcess
    {
        
        protected virtual void UpdateSellIn(IProduct product)
        {
            product.SellIn -= 1;
        }

        protected virtual void UpdateQuality(IProduct product)
        {
            product.Quality -= 1;
        }

        public virtual void Execute(IProduct product)
        {

            UpdateQuality(product);
            if (product.SellIn < 0)
            {
                //Once the sell by date has passed, Quality degrades twice as fast 
                UpdateQuality(product);
            }


            UpdateSellIn(product);

            ValidateQuality(product);
        }

        public void ValidateQuality(IProduct product)
        {
            if (product.Quality > 50)
            {
                product.Quality = 50;
            }
            if (product.Quality < 0)
            {
                product.Quality = 0;
            }
        }
    }
}
