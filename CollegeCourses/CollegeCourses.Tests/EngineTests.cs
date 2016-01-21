using CollegeCourses.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System.Collections.Generic;
using System.Linq;

namespace CollegeCourses.Tests
{
    [TestClass]
    public class EngineTests
    {
        private static IEngine _collegeCoursesEngine;
        private static IMapper _mapper;
        private static StandardKernel _kernel;

        [ClassInitialize]
        public static void TestInitialize(TestContext testContext)
        {
            _kernel = new StandardKernel(new CollegeCoursesNinjectModule());
            _mapper = new Mapper();
            _collegeCoursesEngine = new Engine(_mapper);
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
            var result = _collegeCoursesEngine.DetermineClassOrder(new List<string>());
            Assert.IsNotNull(result);

            Assert.IsTrue(result.Any());
        }
    }
}