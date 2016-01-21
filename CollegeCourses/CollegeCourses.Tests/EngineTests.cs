using Microsoft.VisualStudio.TestTools.UnitTesting;
using CollegeCourses.Business;
using System.Collections.Generic;
using Ninject;

namespace CollegeCourses.Tests
{
    [TestClass]
    public class EngineTests
    {
        private static IEngine _collegeCoursesEngine;
        private static StandardKernel _kernel;

        [ClassInitialize]
        public static void TestInitialize(TestContext testContext)
        {
            _kernel = new StandardKernel(new CollegeCoursesNinjectModule());
            _collegeCoursesEngine = new Engine();
        }

        [TestMethod]
        public void EngineIsValidTest()
        {
            Assert.IsNotNull(_collegeCoursesEngine);
            Assert.IsInstanceOfType(_collegeCoursesEngine, typeof(IEngine));
        }

        [TestMethod]
        public void DetermineClassOrderTest()
        {
            _collegeCoursesEngine.DetermineClassOrder(new List<string>());
        }

    }
}