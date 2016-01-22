using CollegeCourses.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System;
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

        private static List<string> ValidInput1 = new List<string>
        {
            "Introduction to Paper Airplanes:",
            "Advanced Throwing Techniques: Introduction to Paper Airplanes",
            "History of Cubicle Siege Engines: Rubber Band Catapults 101",
            "Advanced Office Warfare: History of Cubicle Siege Engines",
            "Rubber Band Catapults 101:",
            "Paper Jet Engines: Introduction to Paper Airplanes"
        };

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
        public void DetermineClassOrderReturnsSomethingForValidInputTest()
        {
            var result = _collegeCoursesEngine.DetermineClassOrder(ValidInput1);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public void DetermineClassOrderReturnsCorrectValueForValidInputTest()
        {
            var result = _collegeCoursesEngine.DetermineClassOrder(ValidInput1);
            var joinedResult = string.Join(", ", result);
            var expectedResult = "Introduction to Paper Airplanes, Rubber Band Catapults 101, Advanced Throwing Techniques, Paper Jet Engines, History of Cubicle Siege Engines, Advanced Office Warfare";
            Assert.AreEqual(joinedResult, expectedResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void DetermineClassOrderThrowsExceptionForInvalidInput()
        {
            var invalidInput = new List<string>
            {
                "Intro to Arguing on the Internet: Godwin’s Law",
                "Understanding Circular Logic: Intro to Arguing on the Internet",
                "Godwin’s Law: Understanding Circular Logic"
            };
            var result = _collegeCoursesEngine.DetermineClassOrder(invalidInput);
        }
    }
}