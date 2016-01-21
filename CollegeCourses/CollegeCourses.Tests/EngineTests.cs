using Microsoft.VisualStudio.TestTools.UnitTesting;
using CollegeCourses.Business;
using System.Collections.Generic;

namespace CollegeCourses.Tests
{
    [TestClass]
    public class EngineTests
    {
        private static IEngine _collegeCoursesEngine;

        [ClassInitialize]
        public static void TestInitialize(TestContext testContext)
        {
            _collegeCoursesEngine = new Engine();
        }

        [TestMethod]
        public void EngineIsValidTest()
        {
            Assert.IsNotNull(_collegeCoursesEngine);
            Assert.IsInstanceOfType(_collegeCoursesEngine, typeof(Engine));
        }

        [TestMethod]
        public void DetermineClassOrderTest()
        {
            _collegeCoursesEngine.DetermineClassOrder(new List<string>());
        }

    }
}