using Code4Fun_Leone_2015_04_18;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace Code4Fun_Leone_2015_04_18_Test
{
    [TestClass()]
    public class NetworkInformationParserTest
    {


        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        /// <summary>
        /// Test if the NetworkInformation is properly parsed (normal use)
        /// </summary>
        [TestMethod()]
        [DeploymentItem("Code4Fun_Leone_2015-04-18.dll")]
        public void ParseFlatFile_ParseFlatFile()
        {
            string startupPath = System.AppDomain.CurrentDomain.BaseDirectory;
            string filename = Path.Combine(startupPath, @"..\..\Test_Data\1.tsv");
            Console.WriteLine(filename);
            char delimiter = '\t';
            NetworkInformation expected = new NetworkInformation(1, 3, 50);
            NetworkInformation actual;
            actual = NetworkInformationParser_Accessor.ParseFlatFile(filename, delimiter);
            Assert.IsTrue(expected.Equals(actual));

        }

        /// <summary>
        /// Test if the method throws an exception when the file is incomplete
        /// </summary>
        [TestMethod()]
        [DeploymentItem("Code4Fun_Leone_2015-04-18.dll")]
        [ExpectedException(typeof(System.Exception))]
        public void ParseFlatFile_IncompleteFile()
        {
            string startupPath = System.AppDomain.CurrentDomain.BaseDirectory;
            string filename = Path.Combine(startupPath, @"..\..\Test_Data2\3.tsv");
            Console.WriteLine(filename);
            char delimiter = '\t';
            NetworkInformationParser_Accessor.ParseFlatFile(filename, delimiter);

        }

        /// <summary>
        /// Test if the method throws an exception when the file does not exists
        /// </summary>
        [TestMethod()]
        [DeploymentItem("Code4Fun_Leone_2015-04-18.dll")]
        [ExpectedException(typeof(System.IO.FileNotFoundException))]
        public void ParseFlatFile_FileNotFound()
        {
            string startupPath = System.AppDomain.CurrentDomain.BaseDirectory;
            string filename = Path.Combine(startupPath, @"..\..\Test_Data2\filenotfound.tsv");
            Console.WriteLine(filename);
            char delimiter = '\t';
            NetworkInformationParser_Accessor.ParseFlatFile(filename, delimiter);

        }

        /// <summary>
        /// Test if the method throws an exception when the file contains a duplicate key
        /// </summary>
        [TestMethod()]
        [DeploymentItem("Code4Fun_Leone_2015-04-18.dll")]
        [ExpectedException(typeof(System.Exception))]
        public void ParseFlatFile_DuplicateKey()
        {
            string startupPath = System.AppDomain.CurrentDomain.BaseDirectory;
            string filename = Path.Combine(startupPath, @"..\..\Test_Data3\4.tsv");
            Console.WriteLine(filename);
            char delimiter = '\t';
            NetworkInformationParser_Accessor.ParseFlatFile(filename, delimiter);

        }

        /// <summary>
        /// Test if all the NetworkInformations are properly parsed (normal use)
        /// </summary>
        [TestMethod()]
        [DeploymentItem("Code4Fun_Leone_2015-04-18.dll")]
        public void ParseFlatFiles_ParseFlatFiles()
        {
            string startupPath = System.AppDomain.CurrentDomain.BaseDirectory;
            string path = Path.Combine(startupPath, @"..\..\Test_Data");
            Console.WriteLine(path);
            string searchPattern = "*.tsv";
            char delimiter = '\t';
            List<NetworkInformation> expected = new List<NetworkInformation>();
            expected.Add(new NetworkInformation(1, 3, 50));
            expected.Add(new NetworkInformation(5, 7, 100));
            List<NetworkInformation> actual;
            actual = NetworkInformationParser_Accessor.ParseFlatFiles(path, searchPattern, delimiter);
            Assert.AreEqual(expected.Count, actual.Count);
            Assert.IsTrue(expected.Exists(x => x.Equals(actual[0])));
            Assert.IsTrue(expected.Exists(x => x.Equals(actual[1])));
        }

        /// <summary>
        /// Test if the method throws an exception when the directory does not exists
        /// </summary>
        [TestMethod()]
        [DeploymentItem("Code4Fun_Leone_2015-04-18.dll")]
        [ExpectedException(typeof(System.IO.DirectoryNotFoundException))]
        public void ParseFlatFiles_DirectoryNotFound()
        {
            string startupPath = System.AppDomain.CurrentDomain.BaseDirectory;
            string path = Path.Combine(startupPath, @"..\..\directorynotfound");
            Console.WriteLine(path);
            string searchPattern = "*.tsv";
            char delimiter = '\t';
            NetworkInformationParser_Accessor.ParseFlatFiles(path, searchPattern, delimiter);

        }


        /// <summary>
        /// Test if the method throws an exception when a file is incomplete
        /// </summary>
        [TestMethod()]
        [DeploymentItem("Code4Fun_Leone_2015-04-18.dll")]
        [ExpectedException(typeof(System.Exception))]
        public void ParseFlatFiles_IncompleteFile()
        {
            string startupPath = System.AppDomain.CurrentDomain.BaseDirectory;
            string path = Path.Combine(startupPath, @"..\..\Test_Data2");
            Console.WriteLine(path);
            string searchPattern = "*.tsv";
            char delimiter = '\t';
            NetworkInformationParser_Accessor.ParseFlatFiles(path, searchPattern, delimiter);

        }

        /// <summary>
        /// Test if the method throws an exception when a file contains a duplicate key
        /// </summary>
        [TestMethod()]
        [DeploymentItem("Code4Fun_Leone_2015-04-18.dll")]
        [ExpectedException(typeof(System.Exception))]
        public void ParseFlatFiles_DuplicateKey()
        {
            string startupPath = System.AppDomain.CurrentDomain.BaseDirectory;
            string path = Path.Combine(startupPath, @"..\..\Test_Data3");
            Console.WriteLine(path);
            string searchPattern = "*.tsv";
            char delimiter = '\t';
            NetworkInformationParser_Accessor.ParseFlatFiles(path, searchPattern, delimiter);

        }
    }
}
