using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HouseStats
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "HouseStats.csv");
            var fileContents = ReadHouseStats(fileName);
        }

        public static string ReadFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                return reader.ReadToEnd();
            }
        }

        public static List<String[]> ReadHouseStats(string fileName)
        {
            var HouseStats = new List<String[]>();
            using (var reader = new StreamReader(fileName))
            {
                string line = "";
                reader.ReadLine();
                while((line = reader.ReadLine()) != null)
                {
                    var house = new House();
                    string[] values = line.Split(',');

                    house.Address = values[0];

                    if (int.TryParse(values[1], out int sellingPrice))
                    {
                        house.SellingPrice = sellingPrice;
                    }

                    if (DateTime.TryParse(values[2], out DateTime dateSold))
                    {
                        house.DateSold = dateSold;
                    }
                    
                    if (int.TryParse(values[3], out int rooms))
                    {
                        house.Rooms = rooms;
                    }

                    if (int.TryParse(values[4], out int squareMetersGroundFloor))
                    {
                        house.SquareMetersGroundFloor = squareMetersGroundFloor;
                    }

                    if (int.TryParse(values[5], out int squareMetersSecondFloor))
                    {
                        house.SquareMetersSecondFloor = squareMetersSecondFloor;
                    }

                    if (int.TryParse(values[7], out int squareMetersGarden))
                    {
                        house.SquareMetersGarden = squareMetersGarden;
                    }

                    HouseStats.Add(values);
                }
            }
            return HouseStats;
        }

    }

}
