using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseStats
{
    public class House
    {
        public string Address { get; set; }
        public int SellingPrice { get; set; }
        public DateTime DateSold { get; set; }
        public int Rooms { get; set; }
        public int SquareMetersGroundFloor { get; set; }
        public int SquareMetersSecondFloor { get; set; }
        public int SquareMetersGarden { get; set; }
        public double SquareMetersTotal
        {
            get
            {
                return (double)SquareMetersGroundFloor + (double)SquareMetersSecondFloor;
            }
        }
    }
}
