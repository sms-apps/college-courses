﻿using CollegeCourses.Business;
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

            List<string> validInput = new List<string>
            {
                "Introduction to Paper Airplanes:",
                "Advanced Throwing Techniques: Introduction to Paper Airplanes",
                "History of Cubicle Siege Engines: Rubber Band Catapults 101",
                "Advanced Office Warfare: History of Cubicle Siege Engines",
                "Rubber Band Catapults 101:",
                "Paper Jet Engines: Introduction to Paper Airplanes"
            };
            result = _collegeCoursesEngine.DetermineClassOrder(validInput);
            Assert.IsTrue(result.Any());

            //var joinedResult = string.Join(", ", result);
            //var expectedResult = "Introduction to Paper Airplanes, Rubber Band Catapults 101, Paper Jet Engines, Advanced Throwing Techniques, History of Cubicle Siege Engines, Advanced Office Warfare";
            //Assert.AreEqual(joinedResult, expectedResult);
        }
    }
}