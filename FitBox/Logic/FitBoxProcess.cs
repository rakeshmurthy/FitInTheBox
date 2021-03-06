using System;
using FitBox.DomainModel;

namespace FitBox.Logic
{
    public class FitBoxProcess
    {
        /// <summary>
        /// Analyse the boxes. 
        /// Facility to calculate volumes of boxes and
        /// additionally, check and set which box is bigger
        /// </summary>
        /// <param name="boxOne"></param>
        /// <param name="boxTwo"></param>
        public int AnaylseBoxes(Box boxOne, Box boxTwo)
        {
            var _ = CalculateVolumeOfBox(boxOne).Volume > CalculateVolumeOfBox(boxTwo).Volume ? (boxOne.Big = true) : (boxTwo.Big = false);

            return boxOne.Big ? boxOne.Id : boxTwo.Id;
        }

        /// <summary>
        /// Function to Calculate Volume of Box. 
        /// This is the core logic of this project. 
        /// Hence, this has been private protected
        /// </summary>
        /// <param name="box"></param>
        private Box CalculateVolumeOfBox(Box box)
        {
            box.Type = (box.Length == box.Breath && box.Breath == box.Height) ? "Square box" : "Rectangular box";
            box.Volume = (box.Length * box.Breath * box.Height);
            return box;
        }

        /// <summary>
        /// Use the volumes of the boxes 
        /// to find number of boxes that s
        /// fits in another box
        /// </summary>
        /// <param name="boxOne"></param>
        /// <param name="boxTwo"></param>
        /// <returns></returns>
        public decimal NumberOfBoxesThatFits(Box boxOne, Box boxTwo)
        {
            // Default: assumption boxOne is bigger
            decimal nominator = boxOne.Volume;
            decimal denominator = boxTwo.Volume;

            if (!boxOne.Big)
            {
                nominator = boxTwo.Volume;
                denominator = boxOne.Volume;
            }

            return Convert.ToDecimal(Math.Floor(nominator / denominator));
        }

        /// <summary>
        /// Calculates total weight of the box
        /// </summary>
        /// <param name="totalNumberOfBoxes"></param>
        /// <param name="boxOne"></param>
        /// <param name="boxTwo"></param>
        /// <returns></returns>
        public decimal CalculateTotalWeight(decimal totalNumberOfBoxes, Box boxOne, Box boxTwo)
        {
            // Default: assumption boxTwo is smaller
            decimal totalWeight = (boxTwo.Weight * totalNumberOfBoxes) + boxOne.Weight;

            if (boxTwo.Big)
            {
                totalWeight = (boxOne.Weight * totalNumberOfBoxes) + boxTwo.Weight;
            }

            return totalWeight;
        }
    }
}
