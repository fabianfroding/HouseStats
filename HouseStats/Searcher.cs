using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HouseStats
{
    class Searcher
    {
        public static string GetPage(string pageURL)
        {
            var webClient = new WebClient();
            byte[] googleHome = webClient.DownloadData(pageURL);
            using (var stream = new MemoryStream(googleHome))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
