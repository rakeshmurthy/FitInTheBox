using System;
namespace FitBox.DomainModel
{
    public class Box
    {
        public Box(int i)
        {
            if(i <= 0)
            {
                Id = new Random().Next();
            }
            Id = i;
        }

        /// <summary>
        /// Id for box
        /// </summary>
        public int Id { private set; get; }

        /// <summary>
        /// Length in decimal
        /// </summary>
        public decimal Length { set; get; }

        /// <summary>
        /// Breath in decimal
        /// </summary>
        public decimal Breath { set; get; }

        /// <summary>
        ///Height in decimal
        /// </summary>
        public decimal Height { set; get; }

        /// <summary>
        /// Flag to indicate big 
        /// </summary>
        public bool Big { set; get; }

        /// <summary>
        /// Volume of the box
        /// </summary>
        public decimal Volume { set; get; }

        /// <summary>
        /// Type of box
        /// </summary>
        public string Type { set; get; }

        /// <summary>
        /// Maximum weight it can hold
        /// </summary>
        public decimal Weight { set; get; }
    }
}
