using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Net;

namespace HouseStats
{
    class Program
    {
        static void Main(string[] args)
        {
            //string currentDirectory = Directory.GetCurrentDirectory();
            //DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            //var fileName = Path.Combine(directory.FullName, "HouseStats.csv");
            //var fileContents = ReadHouseStats(fileName);

            //// TODO: Convert csv data to House objects.

            //fileName = Path.Combine(directory.FullName, "Houses.json"); // Non-existent!
            //var houses = DeserializeHouses(fileName);

            //var topThreeHouses = GetTopThreeHouses(houses);

            //foreach (var house in topThreeHouses)
            //{
            //    Console.WriteLine(house.Address + ", Selling Price: " + house.SellingPrice);
            //}

            //fileName = Path.Combine(directory.FullName, "TopThreeHouses.json");
            //SerializeHousesToFile(topThreeHouses, fileName);
            Console.WriteLine(Searcher.GetPage("https://www.google.com"));

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

        public static void SerializeHousesToFile(List<House> houses, string fileName)
        {
            var serializer = new JsonSerializer();
            using (var writer = new StreamWriter(fileName))
            using (var jsonWriter = new JsonTextWriter(writer))
            {
                serializer.Serialize(jsonWriter, houses);
            }
        }

        public static List<House> DeserializeHouses(string fileName)
        {
            var houses = new List<House>();
            var serializer = new JsonSerializer();
            using (var reader = new StreamReader(fileName))
            using (var jsonReader = new JsonTextReader(reader))
            {
                houses = serializer.Deserialize<List<House>>(jsonReader);
            }
            return houses;
        }

        public static List<House> GetTopThreeHouses(List<House> houses)
        {
            var topThreeHouses = new List<House>();
            houses.Sort(new HouseComparer());
            int counter = 0;
            foreach(var house in houses)
            {
                topThreeHouses.Add(house);
                counter++;
                if (counter == 3)
                    break;
            }
            return topThreeHouses;
        }

    }

}
