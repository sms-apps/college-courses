using CollegeCourses.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CollegeCourses.Business
{
    public class Engine : IEngine
    {
        private readonly IMapper _mapper;

        public Engine(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<string> DetermineClassOrder(IEnumerable<string> classes)
        {
            var result = new List<string>();

            var coursesList = _mapper.ToCourses(classes);
            var coursesWithNoPrerequisite = coursesList.Where(c => string.IsNullOrWhiteSpace(c.PrerequisiteTitle));

            if (!coursesWithNoPrerequisite.Any())
            {
                throw new ApplicationException("Must have at least one course with no prerequisites!");
            }

            result.AddRange(coursesWithNoPrerequisite.Select(f => f.Title));
            foreach (var baseCourse in coursesWithNoPrerequisite.Select(f => f.Title))
            {
                result.AddRange(GetAllCoursesWithAPrerequisiteOf(coursesList, baseCourse));
            }
            return result;
        }

        private IEnumerable<string> GetAllCoursesWithAPrerequisiteOf(IEnumerable<Course> coursesList, string baseCourse)
        {
            var result = new List<string>();

            foreach (var course in coursesList.Where(f => f.PrerequisiteTitle.Equals(baseCourse)))
            {
                result.Add(course.Title);
                result.AddRange(GetAllCoursesWithAPrerequisiteOf(coursesList, course.Title));
            }

            return result;
        }
    }
}