using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pruebas;

namespace Testing
{
    [TestClass]
    public class EliminarAlumnosTests
    {
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void IsNotValidListTest()
        {
            Program.EliminarAlumnoAlAzar(new System.Collections.SortedList());
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void IsNotValidAllListTest()
        {
            Program.EliminarTodosLosAlumnos(new System.Collections.SortedList());
        }
    }
}
