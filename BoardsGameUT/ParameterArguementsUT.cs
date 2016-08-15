using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoardsGame;
using BoardsGame.Input;

namespace BoardsGameUT
{
    [TestClass]
    public class ParameterArguementsUT
    {
        [TestMethod]
        public void EmptyArgumentsArray_NullError()
        {
            string[] args = null;
            EnvArgumentsEngine argEngine = new EnvArgumentsEngine(new ParameterOptions());

            try
            {
                argEngine.Parse(args);
                Assert.Fail("No exception thrown");
            }
            catch(Exception nex)
            {
                Assert.IsTrue(nex is NullReferenceException);
            }
        }

        [TestMethod]
        public void EmptyArgumentsArray_EmptyError()
        {
            string[] args = new string[0];
            EnvArgumentsEngine argEngine = new EnvArgumentsEngine(new ParameterOptions());

            try
            {
                argEngine.Parse(args);
            }
            catch(Exception ex)
            {
                Assert.IsTrue(ex is ArgumentException);
                Assert.IsTrue(ex.Message == ArgsTypeResource.PA_BOARD_NAME_EMPTY);
            }
        }

        [TestMethod]
        public void EmptyArgumentsArray_OnlyBoardKeyNoValue()
        {
            string[] args = new string[1] { "-b" };
            EnvArgumentsEngine argEngine = new EnvArgumentsEngine(new ParameterOptions());

            try
            {
                argEngine.Parse(args);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ArgumentException);
                Assert.IsTrue(ex.Message == ArgsTypeResource.PA_BOARD_NAME_EMPTY);
            }
        }

        [TestMethod]
        public void EmptyArgumentsArray_Unknown()
        {
            string[] args = new string[1] { "unknown" };
            EnvArgumentsEngine argEngine = new EnvArgumentsEngine(new ParameterOptions());

            try
            {
                argEngine.Parse(args);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ArgumentException);
                Assert.IsTrue(ex.Message == ArgsTypeResource.PA_BOARD_NAME_EMPTY);
            }
        }

        [TestMethod]
        public void EmptyArgumentsArray_NoCenter()
        {
            string[] args = new string[2] { "-b", "abalone" };
            EnvArgumentsEngine argEngine = new EnvArgumentsEngine(new ParameterOptions());

            try
            {
                argEngine.Parse(args);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ArgumentException);
                Assert.IsTrue(ex.Message == ArgsTypeResource.PA_CENTER_EMPTY);
            }
        }

        [TestMethod]
        public void EmptyArgumentsArray_NoRadius()
        {
            string[] args = new string[4] { "-pc", "250,250", "-b", "abalone" };
            EnvArgumentsEngine argEngine = new EnvArgumentsEngine(new ParameterOptions());

            try
            {
                argEngine.Parse(args);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ArgumentException);
                Assert.IsTrue(ex.Message == ArgsTypeResource.PA_RADIUS_EMPTY);
            }
        }
    }
}
