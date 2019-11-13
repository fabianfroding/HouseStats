using Newtonsoft.Json;
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
        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }
        [JsonProperty(PropertyName = "selling_price")]
        public int SellingPrice { get; set; }
        [JsonProperty(PropertyName = "date_sold")]
        public DateTime DateSold { get; set; }
        [JsonProperty(PropertyName = "rooms")]
        public int Rooms { get; set; }
        [JsonProperty(PropertyName = "square_meters_ground_floor")]
        public int SquareMetersGroundFloor { get; set; }
        [JsonProperty(PropertyName = "square_meters_second_floor")]
        public int SquareMetersSecondFloor { get; set; }
        [JsonProperty(PropertyName = "square_meters_garden")]
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
