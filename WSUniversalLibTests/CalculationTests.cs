using Microsoft.VisualStudio.TestTools.UnitTesting;
using WSUniversalLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSUniversalLib.Tests
{
    [TestClass()]
    public class CalculationTests
    {
        [TestMethod()]
        public void Check_AllDataRight()
        {
            int expected = 114147;

            Calculation calc = new Calculation();
            int actual = calc.GetQuantityForProduct(3,1,15,20,45);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Check_TypeProductNoNormal()
        {
            int expected = -1;

            Calculation calc = new Calculation();
            int actual = calc.GetQuantityForProduct(100, 1, 15, 20, 45);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Check_TypeMaterialNoNormal()
        {
            int expected = -1;

            Calculation calc = new Calculation();
            int actual = calc.GetQuantityForProduct(3, -91, 15, 20, 45);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Check_CountNoNormal()
        {
            int expected = -1;

            Calculation calc = new Calculation();
            int actual = calc.GetQuantityForProduct(3, 1, -10, 20, 45);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Check_WidthNoNormal()
        {
            int expected = -1;

            Calculation calc = new Calculation();
            int actual = calc.GetQuantityForProduct(3, 1, 15, -50, 45);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Check_LengthNoNormal()
        {
            int expected = -1;

            Calculation calc = new Calculation();
            int actual = calc.GetQuantityForProduct(3, 1, 15, 20, -35);

            Assert.AreEqual(expected, actual);
        }
    }
}