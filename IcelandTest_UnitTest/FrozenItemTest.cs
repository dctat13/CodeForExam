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
    public class FrozenItemTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FrozenItemFactory_EqualPropertyValuesAsDefined()
        {
            //assign
            IProductFactory factory = new FrozenItemFactory();
            string label = "Frozen Item";
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
        public void FrozenItemFactory_NotEqualPropertyValuesAsDefined()
        {
            //assign
            IProductFactory factory = new FrozenItemFactory();
            string label = "Frozen Item";
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
        public void FrozenItemFactory_QualityDecreaseBy1AsDayPass()
        {
            //assign
            IProductFactory factory = new FrozenItemFactory();
            string label = "Frozen Item";
            int sellIn = 1;
            int quality = 1;
            IProductProcess process = new FrozenItemProcess();

            var product = new FrozenItem()
            {
                Label = label,
                ProductType = ProductType.FrozenItem,
                Quality = quality,
                SellIn = sellIn
            };

            //test
            process.Execute(product);


            //result
            Assert.AreEqual(quality - 1, product.Quality);
            Assert.AreEqual(sellIn - 1, product.SellIn);
        }


        [Test]
        public void FrozenItemFactory_SellInDecreasedAsDayPassing()
        {
            //assign
            IProductFactory factory = new FrozenItemFactory();
            string label = "Frozen Item";
            int sellIn = 1;
            int quality = 1;
            IProductProcess process = new FrozenItemProcess();

            var product = new FrozenItem()
            {
                Label = label,
                ProductType = ProductType.FrozenItem,
                Quality = quality,
                SellIn = sellIn
            };

            //test
            process.Execute(product);


            //result
            Assert.AreEqual(sellIn - 1, product.SellIn);
        }

        [Test]
        public void FrozenItemFactory_QualityMoreThan50()
        {
            //assign
            IProductFactory factory = new FrozenItemFactory();
            string label = "Frozen Item";
            int sellIn = 1;
            int quality = 60;
            IProductProcess process = new FrozenItemProcess();

            var product = new FrozenItem()
            {
                Label = label,
                ProductType = ProductType.FrozenItem,
                Quality = quality,
                SellIn = sellIn
            };

            //test
            process.Execute(product);


            //result
            Assert.AreEqual(50, product.Quality);
        }

        [Test]
        public void FrozenItemFactory_QualityLessThanZero()
        {
            //assign
            IProductFactory factory = new FrozenItemFactory();
            string label = "Frozen Item";
            int sellIn = 10;
            int quality = -5;
            IProductProcess process = new FrozenItemProcess();

            var product = new FrozenItem()
            {
                Label = label,
                ProductType = ProductType.FrozenItem,
                Quality = quality,
                SellIn = sellIn
            };

            //test
            process.Execute(product);


            //result
            Assert.AreEqual(0, product.Quality);
        }
    }
}
