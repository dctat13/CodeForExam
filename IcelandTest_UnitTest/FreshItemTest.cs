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
    class FreshItemTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FreshItemFactory_EqualPropertyValuesAsDefined()
        {
            //assign
            IProductFactory factory = new FreshItemFactory();
            string label = "Fresh Item";
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
        public void FreshItemFactory_NotEqualPropertyValuesAsDefined()
        {
            //assign
            IProductFactory factory = new FreshItemFactory();
            string label = "Fresh Item";
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
        public void FreshItemFactory_QualityDecreaseByTheDoubleOfFrozenItem()
        {
            //assign
            IProductFactory factory = new FreshItemFactory();
            string freshItemlabel = "Fresh Item";
            string frozenItemlabel = "Frozen Item";
            int sellIn = 6;
            int quality = 10;
            IProductProcess freshItemProcess = new FreshItemProcess();
            IProductProcess frozenItemProcess = new FrozenItemProcess();

            var freshProduct = new FreshItem()
            {
                Label = freshItemlabel,
                ProductType = ProductType.FreshItem,
                Quality = quality,
                SellIn = sellIn
            };
            var frozenProduct = new FrozenItem()
            {
                Label = frozenItemlabel,
                ProductType = ProductType.FrozenItem,
                Quality = quality,
                SellIn = sellIn
            };

            //test
            freshItemProcess.Execute(freshProduct);
            frozenItemProcess.Execute(frozenProduct);


            //result
            Assert.AreEqual(2, (quality - freshProduct.Quality) / (quality - frozenProduct.Quality));
        }


        [Test]
        public void FreshItemFactory_QualityDecreaseBy1AsDayPass()
        {
            //assign
            IProductFactory factory = new FreshItemFactory();
            string label = "Fresh Item";
            int sellIn = 1;
            int quality = 10;
            IProductProcess process = new FreshItemProcess();

            var product = new FreshItem()
            {
                Label = label,
                ProductType = ProductType.FreshItem,
                Quality = quality,
                SellIn = sellIn
            };

            //test
            process.Execute(product);


            //result
            Assert.AreEqual(quality - 2, product.Quality);
            Assert.AreEqual(sellIn - 1, product.SellIn);
        }


        [Test]
        public void FreshItemFactory_SellInDecreasedAsDayPassing()
        {
            //assign
            IProductFactory factory = new FreshItemFactory();
            string label = "Fresh Item";
            int sellIn = 5;
            int quality = 1;
            IProductProcess process = new FreshItemProcess();

            var product = new FreshItem()
            {
                Label = label,
                ProductType = ProductType.FreshItem,
                Quality = quality,
                SellIn = sellIn
            };

            //test
            process.Execute(product);


            //result
            Assert.AreEqual(sellIn - 1, product.SellIn);
        }

        [Test]
        public void FreshItemFactory_QualityMoreThan50()
        {
            //assign
            IProductFactory factory = new FreshItemFactory();
            string label = "Fresh Item";
            int sellIn = 1;
            int quality = 60;
            IProductProcess process = new FreshItemProcess();

            var product = new FreshItem()
            {
                Label = label,
                ProductType = ProductType.FreshItem,
                Quality = quality,
                SellIn = sellIn
            };

            //test
            process.Execute(product);


            //result
            Assert.AreEqual(50, product.Quality);
        }

        [Test]
        public void FreshItemFactory_QualityLessThanZero()
        {
            //assign
            IProductFactory factory = new FreshItemFactory();
            string label = "Fresh Item";
            int sellIn = 10;
            int quality = -5;
            IProductProcess process = new FreshItemProcess();

            var product = new FreshItem()
            {
                Label = label,
                ProductType = ProductType.FreshItem,
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
