using BuilderPath;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BuildPathTest
{
    [TestClass]
    public class UnitTest1
    {
        private readonly string[] lines = new string[] { "Москва → Иркутск", "Брест → Москва", "Иркутск → Владивосток" };
        /// <summary>
        /// Общая проверка на коректность работы программы
        /// </summary>
        [TestMethod]
        public void TestMainMethod()
        {
            BuildPath bp = new BuildPath(lines);
            string expected = "Брест → Москва, Москва → Иркутск, Иркутск → Владивосток";
            Assert.AreEqual(expected, bp.result);
        }
        /// <summary>
        /// Колличество городов
        /// </summary>
        [TestMethod]
        public void TestAmountCity()
        {

            BuildPath bp = new BuildPath(lines);
            int expected = 4;
            Assert.AreEqual(expected, bp.Cities.Count);
        }
        /// <summary>
        /// Колличество направлений
        /// </summary>
        [TestMethod]
        public void TestAmountDirection()
        {

            BuildPath bp = new BuildPath(lines);
            int expected = 3;
            Assert.AreEqual(expected, bp.Directions.Count);
        }
       
    }
}
