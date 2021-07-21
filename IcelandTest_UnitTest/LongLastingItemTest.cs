using IcelandTest.Factory;
using IcelandTest.Interfaces;
using IcelandTest.Models;
using IcelandTest.Processes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcelandTest_UnitTest
{
    public class LongLastingItemTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AgedBrieFactory_EqualPropertyValuesAsDefined()
        {
            //assign
            IProductFactory factory = new LongLastItemFactoy();
            string label = "Soap";
            int sellIn = 1;
            int quality = 1;

            //test
            var product = factory.Create(label, sellIn, quality);

            //result
            Assert.AreEqual(label, product.Label);
            Assert.AreEqual(sellIn, product.SellIn);
            Assert.AreEqual(quality, product.Quality);
        }

        [Test]
        public void AgedBrieFactory_NotEqualPropertyValuesAsDefined()
        {
            //assign
            IProductFactory factory = new LongLastItemFactoy();
            string label = "Soap";
            int sellIn = 1;
            int quality = 1;

            //test
            var product = factory.Create(label, sellIn, quality);

            //result
            Assert.AreNotEqual(label + "123", product.Label);
            Assert.AreNotEqual(++sellIn, product.SellIn);
            Assert.AreNotEqual(++quality, product.Quality);
        }


        [Test]
        public void AgedBrieFactory_QualitySellinNeverChange()
        {
            //assign
            IProductFactory factory = new LongLastItemFactoy();
            string label = "Soap";
            int sellIn = 1;
            int quality = 1;
            IProductProcess process = new LongLastingItemProcess();

            var product = new LongLastingItem()
            {
                Label = label,
                ProductType = ProductType.LongLastingItem,
                Quality = quality,
                SellIn = sellIn
            };

            //test
            process.Execute(product);


            //result
            Assert.AreEqual(quality, product.Quality);
        }


    }
}
