using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algebra;

namespace UnitTests
{
    [TestClass]
    public class CreateCommandTests
    {
        [TestMethod]
        public void CommandLength()
        {
            AllVariables vars = new AllVariables();
            string response = "";
            try
            {
                response = CreateVariableCommand.Execute(new string[] { "create", "a", "as", "2", "yoi" }, vars);
            }
            catch(Exception ex) { response = ex.Message; }
            Assert.AreEqual("Length of command should be 4, not 5", response);
        }

        [TestMethod]
        public void ValidVariableName()
        {
            AllVariables vars = new AllVariables();
            string response = "";
            try
            {
                response = CreateVariableCommand.Execute(new string[] { "create", "a/", "as", "2" }, vars);
            }
            catch (Exception ex) { response = ex.Message; }
            Assert.AreEqual("a/ is not a valid variable name", response);
        }
        
        [TestMethod]
        public void AlreadyExistingVariable()
        {
            AllVariables vars = new AllVariables();
            vars.CreateVariable("a", 2);
            string response = "";
            try
            {
                response = CreateVariableCommand.Execute(new string[] { "create", "a", "as", "3" }, vars);
            }
            catch (Exception ex) { response = ex.Message; }
            Assert.AreEqual("the variable a already exists", response);
        }

        [TestMethod]
        public void CorrectAsSubstitute()
        {
            AllVariables vars = new AllVariables();
            string response = "";
            try
            {
                response = CreateVariableCommand.Execute(new string[] { "create", "a", "car", "3" }, vars);
            }
            catch (Exception ex) { response = ex.Message; }
            Assert.AreEqual("third word must be \"as\", not car", response);
        }

        [TestMethod]
        public void IsANumber()
        {
            AllVariables vars = new AllVariables();
            string response = "";
            try
            {
                response = CreateVariableCommand.Execute(new string[] { "create", "car", "as", "two" }, vars);
            }
            catch (Exception ex) { response = ex.Message; }
            Assert.AreEqual("two is not a number", response);
        }
    }
}
