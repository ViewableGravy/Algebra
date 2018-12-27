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
            Assert.AreEqual("20", AddCommand.Execute(new string[] { "add", "a", "and", "a", "and", "a", "and", "a" }, vars));
        }

        [TestMethod]
        public void AddNumbers()
        {
            AllVariables vars = new AllVariables();
            string response = "";
            vars.CreateVariable("a", 5);
            Assert.AreEqual("10", response = AddCommand.Execute(new string[] { "add", "5", "and", "5" }, vars));
            try
            {
                response = AddCommand.Execute(new string[] { "add", "a", "and", "5" }, vars);
            }
            catch (Exception ex) { response = ex.Message; }
            Assert.AreEqual("10", response);
            try
            {
                response = AddCommand.Execute(new string[] { "add", "a", "and", "5", "and", "10" }, vars);
            }
            catch (Exception ex) { response = ex.Message; }
            Assert.AreEqual("20", response);
            try
            {
                response = AddCommand.Execute(new string[] { "add", "a", "and", "5.2" }, vars);
            }
            catch (Exception ex) { response = ex.Message; }
            Assert.AreEqual("10.2", response);
            try
            {
                response = AddCommand.Execute(new string[] { "add", "a", "and", "5.2.2" }, vars);
            }
            catch (Exception ex) { response = ex.Message; }
            Assert.AreEqual("5.2.2 is not a valid number", response);
        }

        [TestMethod]
        public void AddNonExistingVariables()
        {
            AllVariables vars = new AllVariables();
            string response = "";
            vars.CreateVariable("a", 5);
            try
            {
                response = AddCommand.Execute(new string[] { "add", "b", "and", "a" }, vars);
            }
            catch (Exception ex) { response = ex.Message; }
            Assert.AreEqual("The variable b does not currently exist", response);

            try
            {
                response = AddCommand.Execute(new string[] { "add", "a", "and", "a", "and", "b" }, vars);
            }
            catch (Exception ex) { response = ex.Message; }
            Assert.AreEqual("The variable b does not currently exist", response);

            try
            {
                response = AddCommand.Execute(new string[] { "add", "a", "and", "b" }, vars);
            }
            catch (Exception ex) { response = ex.Message; }
            Assert.AreEqual("The variable b does not currently exist", response);

            try
            {
                response = AddCommand.Execute(new string[] { "add", "b", "and", "b" }, vars);
            }
            catch (Exception ex) { response = ex.Message; }
            Assert.AreEqual("The variable b does not currently exist", response);
            
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
