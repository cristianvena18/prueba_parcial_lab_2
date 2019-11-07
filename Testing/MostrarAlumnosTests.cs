using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pruebas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    [TestClass]
    public class MostrarAlumnosTests
    {
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void IsNotValidListTest()
        {
            Program.MostrarAlumnos(new System.Collections.SortedList());
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void IsNotValidListSuperChargedTest()
        {
            Program.MostrarAlumnos(new System.Collections.SortedList(), "");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsNotValidEntrySuperChargedTest()
        {
            var list = new System.Collections.SortedList
            {
                { 124, "pepito" }
            };

            Program.MostrarAlumnos(list, null);
        }
    }
}
