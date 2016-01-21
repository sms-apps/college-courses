using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeCourses.Business
{
    public interface IEngine
    {
        IEnumerable<string> DetermineClassOrder(IEnumerable<string> classes);
    }
}
