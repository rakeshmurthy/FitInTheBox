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
        /// length in decimal
        /// </summary>
        public decimal length { set; get; }

        /// <summary>
        /// breath in decimal
        /// </summary>
        public decimal breath { set; get; }

        /// <summary>
        /// height in decimal
        /// </summary>
        public decimal height { set; get; }

        /// <summary>
        /// Flag to indicate big 
        /// </summary>
        public bool big { set; get; }

        /// <summary>
        /// volume of the box
        /// </summary>
        public decimal volume { set; get; }

        /// <summary>
        /// Type of box
        /// </summary>
        public string Type { set; get; }
    }
}
