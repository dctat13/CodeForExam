using IcelandTest.Interfaces;
using IcelandTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcelandTest.Processes
{
    public class SeasonalItemProcess : ProductProcess
    {
        protected override void UpdateQuality(IProduct product)
        {
            if (product.SellIn < 0)
            {
                base.UpdateQuality(product);
                return;
            }

            if (product.SellIn <= 10)
            {
                if (product.SellIn > 5)
                {
                    //quality increases by 2 when there are 10 days or less
                    product.Quality += 2;
                }
                else
                {
                    //increases by 3 when there are 5 days or less
                    product.Quality += 3;
                }
            }
            else
            {
                product.Quality += 1;
            }
        }

        private void CheckIfExpired(IProduct product)
        {
            if (DateTime.Now.Date > new DateTime(DateTime.Now.Year, 12, 25))
            {
                product.Quality = 0;
            }
        }

        public override void Execute(IProduct product)
        {
            base.Execute(product);

            //if expired, quality=0
            CheckIfExpired(product);
        }



    }
}
