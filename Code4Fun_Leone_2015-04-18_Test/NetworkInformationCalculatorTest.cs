using Code4Fun_Leone_2015_04_18;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Code4Fun_Leone_2015_04_18_Test
{

    [TestClass()]
    public class NetworkInformationCalculatorTest
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
        /// Test if the NetworkInformation is properly calculate (normal use)
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Code4Fun_Leone_2015-04-18.dll")]
        public void Calculate_Calculate()
        {
            List<NetworkInformation> networkInformations = new List<NetworkInformation>();
            networkInformations.Add(new NetworkInformation(2, 20, 50));
            networkInformations.Add(new NetworkInformation(2, 30.5, 50));

            NetworkInformation expected = new NetworkInformation(4, 25.25, 100);
            NetworkInformation actual;
            actual = NetworkInformationCalculator_Accessor.Calculate(networkInformations);
            Assert.IsTrue(expected.Equals(actual));
        }

        /// <summary>
        /// Test if the NetworkInformation is properly calculate when a file contains negative number of connections
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Code4Fun_Leone_2015-04-18.dll")]
        public void Calculate_NegaiveConnection()
        {
            List<NetworkInformation> networkInformations = new List<NetworkInformation>();
            networkInformations.Add(new NetworkInformation(2, 20, 50));
            networkInformations.Add(new NetworkInformation(2, 30.5, 50));
            networkInformations.Add(new NetworkInformation(-2, 30.5, 50));

            NetworkInformation expected = new NetworkInformation(4, 25.25, 100);
            NetworkInformation actual;
            actual = NetworkInformationCalculator_Accessor.Calculate(networkInformations);
            Assert.IsTrue(expected.Equals(actual));
        }

        /// <summary>
        /// Test if the NetworkInformation is properly calculate if the passed list is empty
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Code4Fun_Leone_2015-04-18.dll")]
        public void Calculate_EmptyList()
        {
            List<NetworkInformation> networkInformations = new List<NetworkInformation>();

            NetworkInformation expected = new NetworkInformation();
            NetworkInformation actual = NetworkInformationCalculator_Accessor.Calculate(networkInformations);
            Assert.IsTrue(expected.Equals(actual));
        }

        /// <summary>
        /// Test if the NetworkInformation is properly calculate if the passed list is null
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Code4Fun_Leone_2015-04-18.dll")]
        public void Calculate_NullList()
        {
            List<NetworkInformation> networkInformations = null;

            NetworkInformation expected = new NetworkInformation();
            NetworkInformation actual = NetworkInformationCalculator_Accessor.Calculate(networkInformations);
            Assert.IsTrue(expected.Equals(actual));

        }

    }
}
