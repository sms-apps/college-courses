using CollegeCourses.Models;
using System.Collections.Generic;

namespace CollegeCourses.Business
{
    public interface IMapper
    {
        IEnumerable<Course> ToCourses(IEnumerable<string> raw);
    }
}
