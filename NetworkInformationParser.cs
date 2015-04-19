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

        private NetworkInformationParser()
        {
        }

        //NOTA2: Valutare la necessità di gestire più formati di file attraverso l'aggiunta di un filetype o di altri metodi

        /// <summary>
        /// Extract the NetworkInformations from all the files in the specified path
        /// </summary> 
        /// <returns>Returns a list of NetworkInformation containing the values presents into the files.</returns>
        /// <param name="path"> The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="searchPattern"> The search string to match against the names of files in path. This parameter can contain a 
        /// combination of valid literal path and wildcard (* and ?) characters, but doesn't support regular expressions.</param>
        /// <param name="delimiter"> The delimiter character between key and value.</param>
        /// <exception cref="System.Exception">Thrown when one or more files does not contains the required informations or a value of the required
        ///  informations is not well-formed  or a files contains one or more duplicated informations</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">Thrown when the directory does not exists.</exception>
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

        /// <summary>
        /// Extract the NetworkInformation from file
        /// </summary> 
        /// <returns>Returns a NetworkInformation containing the values presents into the file.</returns>
        /// <param name="filename"> The file to read.</param>
        /// <param name="delimiter"> The delimiter character between key and value.</param>
        /// <exception cref="System.Exception">Thrown when the file does not contains the required informations or a value of the required
        ///  informations is not well-formed or the file contains one or more duplicated informations</exception>
        /// <exception cref="System.IO.FileNotFoundException">Thrown when the file does not exists.</exception>
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
