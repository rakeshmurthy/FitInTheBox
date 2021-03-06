using System;
using FitBox.DomainModel;
using FitBox.Helper;
using FitBox.Logic;

namespace FitBox
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            HelpMe.DisplayHeader();

            // Read measuring unit
            var unit = Console.ReadLine();

            //Read boxes information
            var boxOne = HelpMe.CollectBoxInfo(new Box(1), unit);
            var boxTwo = HelpMe.CollectBoxInfo(new Box(2), unit);

            //Process the boxes
            var processBox = new FitBoxProcess();
            processBox.AnaylseBoxes(boxOne, boxTwo);
            var numberOfBoxes = processBox.NumberOfBoxesThatFits(boxOne, boxTwo);

            //Display information of boxes and results
            HelpMe.DisplayBoxInformation(boxOne, unit);
            HelpMe.DisplayBoxInformation(boxTwo, unit);
            Console.WriteLine($"Conclusion: \n " +
                              $"Atleast {numberOfBoxes} boxes fit in other box");

            Console.ReadLine();
        }
    }
}
