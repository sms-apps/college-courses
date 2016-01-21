using System.Collections.Generic;

namespace CollegeCourses.Business
{
    public interface IEngine
    {
        IEnumerable<string> DetermineClassOrder(IEnumerable<string> classes);
    }
}
