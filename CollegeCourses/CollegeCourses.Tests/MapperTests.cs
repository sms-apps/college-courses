using CollegeCourses.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CollegeCourses.Business.Tests
{
    [TestClass]
    public class MapperTests
    {
        private static IMapper _mapper;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            _mapper = new Mapper();
        }

        [TestMethod]
        public void MapperIsValidTest()
        {
            Assert.IsNotNull(_mapper);
            Assert.IsInstanceOfType(_mapper, typeof(IMapper));
        }

        [TestMethod]
        public void ToCoursesTest()
        {
            List<string> validInput = new List<string>
            {
                "Introduction to Paper Airplanes:",
                "Advanced Throwing Techniques: Introduction to Paper Airplanes",
                "History of Cubicle Siege Engines: Rubber Band Catapults 101",
                "Advanced Office Warfare: History of Cubicle Siege Engines",
                "Rubber Band Catapults 101:",
                "Paper Jet Engines: Introduction to Paper Airplanes"
            };
            var result = _mapper.ToCourses(validInput);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<Course>));
            Assert.IsTrue(result.Any());
        }
    }
}