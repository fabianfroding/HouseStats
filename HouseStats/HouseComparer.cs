using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseStats
{
    public class HouseComparer : IComparer<House>
    {
        public int Compare(House house1, House house2)
        {
            return house1.SellingPrice.CompareTo(house2.SellingPrice) * -1;
        }
    }
}
