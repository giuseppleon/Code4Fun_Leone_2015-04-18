using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.IO;

namespace Code4Fun_Leone_2015_04_18
{
    class NetworkInformationParser
    {
        public static List<NetworkInformation> ParseFlatFiles(String path, String searchPattern, char delimiter)
        {
            //Check if the directory exists
            if (!Directory.Exists(path))
                throw new DirectoryNotFoundException("The directory " + path + " does not exists");

            //Retrieve the names of files (including their paths) that match the specified search pattern in the specified directory
            string[] filenames = Directory.GetFiles(path, searchPattern);

            //Create an empty list
            List<NetworkInformation> networkInformations = new List<NetworkInformation>();

            //Extract and insert into the list the NetworkInformation present in each file 
            foreach (String f in filenames)
            {
                networkInformations.Add(ParseFlatFile(f, delimiter));
            }

            return networkInformations;
        }

        public static NetworkInformation ParseFlatFile(String filename, char delimiter)
        {
            //Check if the file exists
            if (!File.Exists(filename))
                throw new FileNotFoundException("The file " + filename + " does not exists");

            // Extract only the informations of interest
            Dictionary<String, String> result;
            try
            {
                result = File.ReadLines(filename)
                     .Select(line => line.Split(delimiter))
                     .Where(columns => columns.Length == 2 && (columns[0].Equals("num_connections") || columns[0].Equals("latency_ms") || columns[0].Equals("bandwidth")))
                     .ToDictionary(columns => columns[0], columns => columns[1]);
            }
            catch (ArgumentException)
            {
                throw new Exception("The file " + filename + " contains one or more duplicated informations");
            }

            //Check if all the required information are presents
            if (result.Count != 3)
                throw new Exception("The file " + filename + " does not contains the required informations");

            //Check if values are correct
            int numConnections = 0;
            if (!int.TryParse(result["num_connections"], out numConnections))
                throw new Exception("The value of num_connections key is not numeric");

            //NB: decimal separator: parse with comma and point 
            double latency = 0;
            if (!double.TryParse(result["latency_ms"].Replace(',', '.'), System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture, out latency))
                throw new Exception("The value of latency_ms key is not decimal");

            int bandwidth = 0;
            if (!int.TryParse(result["bandwidth"], out bandwidth))
                throw new Exception("The value of bandwidth key is not numeric");

            return new NetworkInformation(numConnections, latency, bandwidth);
        }
    }
}
