using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algebra;

namespace UnitTests
{
    [TestClass]
    public class AddCommandTests
    {
        [TestMethod]
        public void AddExistingValues()
        {
            AllVariables vars = new AllVariables();
            vars.CreateVariable("a", 5);
            Assert.AreEqual("10", AddCommand.Execute(new string[] { "add", "a", "and", "a" }, vars));
            Assert.AreEqual("15", AddCommand.Execute(new string[] { "add", "a", "and", "a", "and", "a" }, vars));
        }

        [TestMethod]
        public void InvalidVariables()
        {
            AllVariables vars = new AllVariables();
            string response = "";
            vars.CreateVariable("a", 5);
            try
            {
                response = AddCommand.Execute(new string[] { "add", "b", "and", "a" }, vars);
            }
            catch (Exception ex) { response = ex.Message; }
            Assert.AreEqual("the variable b does not currently exist", response);

            try
            {
                response = AddCommand.Execute(new string[] { "add", "a", "and", "a", "and", "b" }, vars);
            }
            catch (Exception ex) { response = ex.Message; }
            Assert.AreEqual("the variable b does not currently exist", response);

            try
            {
                response = AddCommand.Execute(new string[] { "add", "a", "and", "b" }, vars);
            }
            catch (Exception ex) { response = ex.Message; }
            Assert.AreEqual("the variable b does not currently exist", response);

            try
            {
                response = AddCommand.Execute(new string[] { "add", "b", "and", "b" }, vars);
            }
            catch (Exception ex) { response = ex.Message; }
            Assert.AreEqual("the variable b does not currently exist", response);
            
        } 

        [TestMethod]
        public void ValueOtherThanAnd()
        {
            AllVariables vars = new AllVariables();
            string response = "";
            vars.CreateVariable("a", 5);
            try
            {
                response = AddCommand.Execute(new string[] { "add", "a", "not", "a" }, vars);
            }
            catch (Exception ex) { response = ex.Message; }
            Assert.AreEqual("please check your \"and's\"", response);

            try
            {
                response = AddCommand.Execute(new string[] { "add", "a", "and", "a", "not", "a" }, vars);
            }
            catch (Exception ex) { response = ex.Message; }
            Assert.AreEqual("please check your \"and's\"", response);
        }

        

    }
}
