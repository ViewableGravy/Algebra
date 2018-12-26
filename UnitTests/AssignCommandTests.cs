using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algebra;
using Shouldly;

namespace UnitTests
{
    [TestClass]
    public class AssignCommandTests
    {
        [TestMethod]
        public void AssignIntegerToExistingVariable()
        {
            AllVariables Variables = new AllVariables();
            Variables.CreateVariable("a", 5);
            AssignCommand.Execute(new string[] { "assign", "2", "to", "a" }, ref Variables);

            Variables._variables[0].Value.ShouldBe(2);
        }

        [TestMethod]
        public void AssignIntegerToNonExistingVariable()
        {
            AllVariables Variables = new AllVariables();
            string exception = "";
            try
            {
                AssignCommand.Execute(new string[] { "assign", "2", "to", "a" }, ref Variables);
            }
            catch (Exception ex) { exception = ex.Message; }

            Assert.AreEqual("Variable does not exist", exception);
        }

        [TestMethod]
        public void FailOnIncorrectLength()
        {
            AllVariables Variables = new AllVariables();
            string exception = "";
            try
            {
                AssignCommand.Execute(new string[] { "assign", "2", "to", "a", "and", "b" }, ref Variables);
            }
            catch (Exception ex) { exception = ex.Message; }

            Assert.AreEqual("incorrect command length", exception);
        }

        [TestMethod]
        public void IncorrectWordSubstituteForTo()
        {
            AllVariables Variables = new AllVariables();
            Variables.CreateVariable("a", 5);
            string exception = "";
            try
            {
                AssignCommand.Execute(new string[] { "assign", "2", "yes", "a" }, ref Variables);
            }
            catch (Exception ex) { exception = ex.Message; }

            Assert.AreEqual("incorrect format", exception);
        }

        [TestMethod]
        public void InputIsANumber()
        {
            AllVariables Variables = new AllVariables();
            Variables.CreateVariable("a", 5);
            string exception = "";
            try
            {
                AssignCommand.Execute(new string[] { "assign", "yes", "yes", "a" }, ref Variables);
            }
            catch (Exception ex) { exception = ex.Message; }

            Assert.AreEqual("not a number", exception);
        }
    }
}
