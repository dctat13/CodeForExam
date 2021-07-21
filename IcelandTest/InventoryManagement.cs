using IcelandTest.Factory;
using IcelandTest.Interfaces;
using IcelandTest.Models;
using IcelandTest.Processes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcelandTest
{
    public class InventoryManagement
    {
        public void Run(Input input)
        {
            IProductFactory productFactory;
            IProduct product;
            IProductProcess process;

            try
            {
                switch (input.ProductType)
                {
                    case ProductType.AgedBrie://AgedBrie
                        productFactory = new AgedBrieFactory();
                        process = new AgedBrieProcess();
                        break;

                    case ProductType.FreshItem://Fresh item
                        productFactory = new FreshItemFactory();
                        process = new FreshItemProcess();
                        break;

                    case ProductType.FrozenItem://Frozen item
                        productFactory = new FrozenItemFactory();
                        process = new FrozenItemProcess();
                        break;

                    case ProductType.LongLastingItem://SOAP
                        productFactory = new LongLastItemFactory();
                        process = new LongLastingItemProcess();
                        break;

                    case ProductType.SeasonalItem://Christmas crackers
                        productFactory = new SeasonalItemFactory();
                        process = new SeasonalItemProcess();
                        break;

                    default:
                        throw new Exception("NO SUCH ITEM");
                }


                product = productFactory.Create(input.Label, input.SellIn, input.Quality);
                process.Execute(product);


                Console.WriteLine(string.Format("{0} {1} {2}", product.Label, product.SellIn, product.Quality));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
