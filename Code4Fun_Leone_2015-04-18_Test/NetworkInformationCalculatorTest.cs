using Code4Fun_Leone_2015_04_18;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Code4Fun_Leone_2015_04_18_Test
{
    
    
    /// <summary>
    ///Classe di test per NetworkInformationCalculatorTest.
    ///Creata per contenere tutti gli unit test NetworkInformationCalculatorTest
    ///</summary>
    [TestClass()]
    public class NetworkInformationCalculatorTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Ottiene o imposta il contesto dei test, che fornisce
        ///funzionalità e informazioni sull'esecuzione dei test corrente.
        ///</summary>
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

        #region Attributi di test aggiuntivi
        // 
        //Durante la scrittura dei test è possibile utilizzare i seguenti attributi aggiuntivi:
        //
        //Utilizzare ClassInitialize per eseguire il codice prima di eseguire il primo test della classe
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Utilizzare ClassCleanup per eseguire il codice dopo l'esecuzione di tutti i test di una classe
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Utilizzare TestInitialize per eseguire il codice prima di eseguire ciascun test
        //
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //Utilizzare TestCleanup per eseguire il codice dopo l'esecuzione di ciascun test
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Test per Calculate
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Code4Fun_Leone_2015-04-18.dll")]
        public void CalculateTest()
        {
            List<NetworkInformation> networkInformations = null; // TODO: Eseguire l'inizializzazione a un valore appropriato
            NetworkInformation expected = null; // TODO: Eseguire l'inizializzazione a un valore appropriato
            NetworkInformation actual;
            actual = NetworkInformationCalculator_Accessor.Calculate(networkInformations);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verificare la correttezza del metodo di test.");
        }
    }
}
