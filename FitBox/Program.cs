using System;
using System.Collections.Generic;
using FitBox.DomainModel;
using FitBox.Helper;
using FitBox.Logic;

namespace FitBox
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Service.DisplayHeader();

            // Read measuring unit
            (string dimension,string mass) = Service.CollectUnitOfMeasurmentInformation();

            //Read boxes information
            (Box boxOne,Box boxTwo) = Service.CollectBoxesInfo(2, dimension, mass);

            //Process the boxes
            var processBox = new FitBoxProcess();
            var bigBox = processBox.AnaylseBoxes(boxOne, boxTwo);
            var totalNumberOfBoxes = processBox.NumberOfBoxesThatFits(boxOne, boxTwo);
            var totalWeight = processBox.CalculateTotalWeight(totalNumberOfBoxes, boxOne, boxTwo);

            //Display information of boxes and results
            Service.DisplayBoxInformation(new List<Box> { boxOne, boxTwo }, dimension, mass);
            Service.DisplayConclusion(bigBox, totalNumberOfBoxes, totalWeight, mass);

            Console.ReadLine();
        }
    }
}
