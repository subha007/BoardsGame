using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoardsGame;

namespace BoardsGameUT
{
    /// <summary>
    /// Summary description for GameBoardFactoryUT
    /// </summary>
    [TestClass]
    public class GameBoardFactoryUT
    {
        public GameBoardFactoryUT()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
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

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void AbaloneBoardObject()
        {
            string[] args = new string[6] { "-b", "abalone", "-pc", "250,250", "-r", "210" };

            EnvArgumentsEngine argEngine = new EnvArgumentsEngine(new ParameterOptions());
            argEngine.Parse(args);

            GameBoardFactory factory = new GameBoardFactory();
            BoardGame bGame = factory.GenerateBoard(argEngine);

            Assert.IsTrue(bGame is AbaloneGame);
        }
    }
}
