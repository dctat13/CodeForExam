using IcelandTest.Factory;
using IcelandTest.Interfaces;
using IcelandTest.Models;
using IcelandTest.Processes;
using NUnit.Framework;
using System;

namespace IcelandTest_UnitTest
{
    public class SeasonalItemTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SeasonalItemFactory_EqualPropertyValuesAsDefined()
        {
            //assign
            IProductFactory factory = new SeasonalItemFactoy();
            string label = "Christmas Crackers";
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
        public void SeasonalItemFactory_NotEqualPropertyValuesAsDefined()
        {
            //assign
            IProductFactory factory = new SeasonalItemFactoy();
            string label = "Christmas Crackers";
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
        public void SeasonalItemFactory_QualityIncreasedBy2AsDayPassing_SellIn_6()
        {
            //assign
            IProductFactory factory = new SeasonalItemFactoy();
            string label = "Christmas Crackers";
            int sellIn = 6;
            int quality = 1;
            IProductProcess process = new SeasonalItemProcess();

            var product = new SeasonalItem()
            {
                Label = label,
                ProductType = ProductType.SeasonalItem,
                Quality = quality,
                SellIn = sellIn
            };

            //test
            process.Execute(product);


            //result
            Assert.AreEqual(quality +2, product.Quality);
        }

        [Test]
        public void SeasonalItemFactory_QualityIncreasedBy2AsDayPassing_SellIn_10()
        {
            //assign
            IProductFactory factory = new SeasonalItemFactoy();
            string label = "Christmas Crackers";
            int sellIn = 10;
            int quality = 1;
            IProductProcess process = new SeasonalItemProcess();

            var product = new SeasonalItem()
            {
                Label = label,
                ProductType = ProductType.SeasonalItem,
                Quality = quality,
                SellIn = sellIn
            };

            //test
            process.Execute(product);


            //result
            Assert.AreEqual(quality + 2, product.Quality);
        }

        [Test]
        public void SeasonalItemFactory_QualityIncreasedBy1AsDayPassing_SellIn_11()
        {
            //assign
            IProductFactory factory = new SeasonalItemFactoy();
            string label = "Christmas Crackers";
            int sellIn = 11;
            int quality = 1;
            IProductProcess process = new SeasonalItemProcess();

            var product = new SeasonalItem()
            {
                Label = label,
                ProductType = ProductType.SeasonalItem,
                Quality = quality,
                SellIn = sellIn
            };

            //test
            process.Execute(product);


            //result
            Assert.AreEqual(quality + 1, product.Quality);
        }

        [Test]
        public void SeasonalItemFactory_QualityIncreasedBy3AsDayPassing_SellIn_5()
        {
            //assign
            IProductFactory factory = new SeasonalItemFactoy();
            string label = "Christmas Crackers";
            int sellIn = 5;
            int quality = 1;
            IProductProcess process = new SeasonalItemProcess();

            var product = new SeasonalItem()
            {
                Label = label,
                ProductType = ProductType.SeasonalItem,
                Quality = quality,
                SellIn = sellIn
            };

            //test
            process.Execute(product);


            //result
            Assert.AreEqual(quality + 3, product.Quality);
        }

        [Test]
        public void SeasonalItemFactory_QualityIncreasedBy2AsDayPassing_SellIn_0()
        {
            //assign
            IProductFactory factory = new SeasonalItemFactoy();
            string label = "Christmas Crackers";
            int sellIn = 0;
            int quality = 1;
            IProductProcess process = new SeasonalItemProcess();

            var product = new SeasonalItem()
            {
                Label = label,
                ProductType = ProductType.SeasonalItem,
                Quality = quality,
                SellIn = sellIn
            };

            //test
            process.Execute(product);


            //result
            Assert.AreEqual(quality + 3, product.Quality);
        }


        [Test]
        public void SeasonalItemFactory_QualityMoreThan50()
        {
            //assign
            IProductFactory factory = new SeasonalItemFactoy();
            string label = "Christmas Crackers";
            int sellIn = 1;
            int quality = 60;
            IProductProcess process = new SeasonalItemProcess();

            var product = new SeasonalItem()
            {
                Label = label,
                ProductType = ProductType.SeasonalItem,
                Quality = quality,
                SellIn = sellIn
            };

            //test
            process.Execute(product);


            //result
            Assert.AreEqual(50, product.Quality);
        }

        [Test]
        public void SeasonalItemFactory_QualityLessThanZero()
        {
            //assign
            IProductFactory factory = new SeasonalItemFactoy();
            string label = "Christmas Crackers";
            int sellIn = 10;
            int quality = -5;
            IProductProcess process = new SeasonalItemProcess();

            var product = new SeasonalItem()
            {
                Label = label,
                ProductType = ProductType.SeasonalItem,
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