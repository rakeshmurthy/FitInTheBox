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
        public void AnaylseBoxes(Box boxOne, Box boxTwo)
        {
            var _ = CalculateVolumeOfBox(boxOne).volume > CalculateVolumeOfBox(boxTwo).volume ? (boxOne.big = true) : (boxTwo.big = false);
        }

        /// <summary>
        /// Function to Calculate Volume of Box. 
        /// This is the core logic of this project. 
        /// Hence, this has been private protected
        /// </summary>
        /// <param name="box"></param>
        private Box CalculateVolumeOfBox(Box box)
        {
            box.Type = (box.length == box.breath && box.breath == box.height) ? "Square box" : "Rectangular box";
            box.volume = (box.length * box.breath * box.height);
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
            decimal nominator = boxOne.volume;
            decimal denominator = boxTwo.volume;

            if (!boxOne.big)
            {
                nominator = boxTwo.volume;
                denominator = boxOne.volume;
            }

            return Convert.ToDecimal(Math.Floor(nominator / denominator));
        }
    }
}
