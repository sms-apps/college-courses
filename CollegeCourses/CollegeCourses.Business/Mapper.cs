using CollegeCourses.Models;
using System;
using System.Collections.Generic;

namespace CollegeCourses.Business
{
    public class Mapper : IMapper
    {
        public IEnumerable<Course> ToCourses(IEnumerable<string> rawCourses)
        {
            var result = new List<Course>();

            foreach (var rawCourse in rawCourses)
            {
                var split = rawCourse.Split(new char[] { ':' }, StringSplitOptions.None);

                result.Add(new Course
                {
                    Title = split[0].Trim(),
                    PrerequisiteTitle = split.Length >= 2
                        ? split[1].Trim()
                        : string.Empty
                });
            }

            return result;
        }
    }
}