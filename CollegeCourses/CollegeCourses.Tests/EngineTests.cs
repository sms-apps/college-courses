using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CollegeCourses.Business;

namespace CollegeCourses.Tests
{
    [TestClass]
    public class EngineTests
    {
        Engine _collegeCoursesEngine;

        [TestInitialize]
        public void TestInitialize()
        {
            _collegeCoursesEngine = new Engine();
        }

        [TestMethod]
        public void EngineIsValid()
        {
            Assert.IsNotNull(_collegeCoursesEngine);
            Assert.IsInstanceOfType(_collegeCoursesEngine, typeof(Engine));
        }


    }
}