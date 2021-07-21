using IcelandTest.Interfaces;
using IcelandTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IcelandTest
{
    public static class InputRecognition
    {
        public static Input Process(string input)
        {
            string pattern = @"\-{0,1}[0-9]+\s-{0,1}[0-9]+";
            string sellInQualityString = Regex.Match(input, pattern).Value;

            string[] splitedsellInQualityString = sellInQualityString.Split(' ');
            int sellIn = int.Parse(splitedsellInQualityString[0].Trim());
            int quality = int.Parse(splitedsellInQualityString[1].Trim());
            string label = input.Replace(sellInQualityString, "").Trim();


            ProductType productType = ProductClassification.Classify(label);


            return new Input()
            {
                Label = label,
                SellIn = sellIn,
                Quality = quality,
                ProductType = productType
            };
        }
    }
}
