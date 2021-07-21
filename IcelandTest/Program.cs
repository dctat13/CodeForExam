﻿using System;
using System.Threading.Tasks;

namespace IcelandTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string input =
@"Aged Brie 1 1
Christmas Crackers -1 2
Christmas Crackers 9 2
Soap 2 2
Frozen Item -1 55
Frozen Item 2 2
INVALID ITEM 2 2
Fresh Item 2 2
Fresh Item -1 5";



            InventoryManagement inventoryManagement = new InventoryManagement();

            foreach (string line in input.Split(Environment.NewLine))
            {
                var result = InputRecognition.Process(line);
                inventoryManagement.Run(result);
            }

            Console.ReadLine();

        }
    }
}
