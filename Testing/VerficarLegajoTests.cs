using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pruebas;

namespace Testing
{
    [TestClass]
    public class VerficarLegajoTests
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void IsNotValidLegajoTest()
        {
            Program.VerificarLegajo(99, new System.Collections.SortedList());
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void IsNotValidListTest()
        {
            Program.VerificarLegajo(234, new System.Collections.SortedList());
        }

        [TestMethod]
        public void IsLegajoOK()
        {
            var list = new System.Collections.SortedList
            {
                { 124, "pepito" }
            };

            bool response = Program.VerificarLegajo(123, list);

            Assert.IsTrue(response);
        }

        [TestMethod]
        public void IsLegajoNotOK()
        {
            var list = new System.Collections.SortedList();
            list.Add(123, "pepito");

            bool response = Program.VerificarLegajo(123, list);

            Assert.IsFalse(response);
        }
    }
}
