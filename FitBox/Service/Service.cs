using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using FitBox.DomainModel;

namespace FitBox.Helper
{
    public static class Service
    {
        public static (Box boxOne,Box boxTwo) CollectBoxesInfo(int numberOfBoxes, string dimension, string mass)
        {
            List<Box> boxes = new List<Box>();

            for(int i = 1; i <= numberOfBoxes; i++)
            {
                Console.WriteLine($"Please enter the size of box {i}");
                Box box = new Box(i);
                Console.Write($"Length in {dimension}: ");
                box.Length = ReadDimension(Console.ReadLine());
                Console.Write($"Breath in {dimension}: ");
                box.Breath = ReadDimension(Console.ReadLine());
                Console.Write($"Height in {dimension}: ");
                box.Height = ReadDimension(Console.ReadLine());
                Console.Write($"Weight of this box in {mass}: ");
                box.Weight = ReadDimension(Console.ReadLine());
                boxes.Add(box);
            }            

            return (boxes[0], boxes[1]);
        }

        private static decimal ReadDimension(string input)
        {
            again:
            if (!Regex.IsMatch(input, @"^[1-9]\d*$"))
            {
                Console.WriteLine($"Oops entered value is not numeric or cannot be 0");
                Console.WriteLine($"try again with numeric value greater than 0:");
                input = Console.ReadLine();
                goto again;
            }
            return Convert.ToDecimal(input);
        }

        public static void DisplayBoxInformation(List<Box> boxes, string dimension, string mass)
        {
            foreach(var box in boxes)
            {
                Console.WriteLine("==================================");
                Console.WriteLine($"Box {box.Id} has \n" +
                                  $"Length: {box.Length}{dimension} \n" +
                                  $"Breath: {box.Height}{dimension} \n" +
                                  $"Height: {box.Height}{dimension} \n" +
                                  $"Weight: {box.Weight}{mass} \n" +
                                  $"Volume of this box: {box.Volume} {dimension}\u00b3 \n" +
                                  $"This box is: {box.Type}\n");
                Console.WriteLine("==================================");
            }            
        }

        public static void DisplayHeader()
        {
            Console.WriteLine("==================================");
            Console.WriteLine("Welcome to Fit Box");
            Console.WriteLine("==================================");            
        }

        public static (string dimension, string mass) CollectUnitOfMeasurmentInformation()
        {
            Console.WriteLine("Unit of measurement for dimensions");
            Console.WriteLine("cm => centimeter");
            Console.WriteLine("inch => inches");
            Console.WriteLine("==================================");
            Console.WriteLine("What shall be used :");

            dim:
            string dimension = Console.ReadLine();
            if (!Constants.Dimensions.Contains(dimension))
            {
                Console.WriteLine($"It has to be either :");
                Constants.Dimensions.ForEach(x => Console.WriteLine(x));
                Console.WriteLine($"try again :");
                goto dim;
            }    
                
            mas:
            Console.WriteLine("==================================");
            Console.WriteLine("Unit of measurement for mass");
            Console.WriteLine("gms => gram");
            Console.WriteLine("kgs => kilogram");
            Console.WriteLine("==================================");
            Console.WriteLine("What shall be used :");

            string mass = Console.ReadLine();
            if (!Constants.Mass.Contains(mass))
            {
                Console.WriteLine($"It has to be either :");
                Constants.Mass.ForEach(x => Console.WriteLine(x));
                Console.WriteLine($"try again :");
                goto mas;
            }

            return (dimension, mass);
        }

        public static void DisplayConclusion(int bigBox, decimal numberOfBoxes, decimal totalWeight, string mass)
        {
            Console.WriteLine($"Conclusion: \n" +
                              $"Box number : {bigBox} is bigger box among the two boxes. \n" +
                              $"Atleast {numberOfBoxes} boxes fit in other box. \n" +
                              $"Final weight of bigger box containing small boxes will be {totalWeight} {mass}");
        }
    }
}
