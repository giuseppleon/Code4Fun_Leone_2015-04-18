using Code4Fun_Leone_2015_04_18;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Code4Fun_Leone_2015_04_18_Test
{
    [TestClass()]
    public class NetworkInformationTest
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
        /// Test if the guidelines for overloading Equals are respected
        /// </summary>
        [TestMethod()]
        public void Equals_Equals()
        {
            NetworkInformation x = new NetworkInformation(1, 5, 5);
            NetworkInformation y = new NetworkInformation(1, 5, 5);
            NetworkInformation z = new NetworkInformation(1, 5, 5);
            NetworkInformation k1 = new NetworkInformation(2, 5, 5);
            NetworkInformation k2 = new NetworkInformation(1, 6, 5);
            NetworkInformation k3 = new NetworkInformation(1, 5, 6);

            Assert.IsFalse(x.Equals(k1));
            Assert.IsFalse(x.Equals(k2));
            Assert.IsFalse(x.Equals(k3));
            Assert.IsTrue(x.Equals(y));

            //x.Equals(x) return true
            Assert.IsTrue(x.Equals(x));

            //x.Equals(y) return the same value as y.Equals(x)
            Assert.AreEqual(x.Equals(y), y.Equals(x));
            Assert.AreEqual(x.Equals(k1), k1.Equals(x));

            //if (x.Equals(y) && y.Equals(z)) return true, then x.Equals(z) returns true
            Assert.IsTrue(x.Equals(y) && y.Equals(z));
            Assert.IsTrue(x.Equals(z));

            //x.Equals(null) returns false
            Assert.IsFalse(x.Equals(null));
        }
    }
}
