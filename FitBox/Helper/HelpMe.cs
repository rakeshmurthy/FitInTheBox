using System;
using System.Text.RegularExpressions;
using FitBox.DomainModel;

namespace FitBox.Helper
{
    public static class HelpMe
    {
        public static Box CollectBoxInfo(Box box, string unit)
        {
            Console.WriteLine($"Please enter the size of box {box.Id}");

            Console.Write($"Length in {unit}: ");
            box.length = ReadDimension(Console.ReadLine());
            Console.Write($"Breath in {unit}: ");
            box.breath = ReadDimension(Console.ReadLine());
            Console.Write($"Height in {unit}: ");
            box.height = ReadDimension(Console.ReadLine());

            return box;
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

        public static void DisplayBoxInformation(Box box, string unit)
        {
            Console.WriteLine($"================================================");
            Console.WriteLine($"Box {box.Id} has \n " +
                              $"Length: {box.length}{unit} " +
                              $"\n Breath: {box.height}{unit} \n " +
                              $"Height: {box.height}{unit} " +
                              $"\n Volume of this box: {box.volume} {unit}\u00b3 \n " +
                              $"This box is: {box.Type}\n");
            Console.WriteLine($"================================================");

        }

        public static void DisplayHeader()
        {
            Console.WriteLine("==================");
            Console.WriteLine("Welcome to Fit Box");
            Console.WriteLine("==================");
            Console.WriteLine("Unit of Measurement");
            Console.WriteLine("cm => centimeter");
            Console.WriteLine("inch => inches");
            Console.WriteLine("What shall be used :");
        }
    }
}
