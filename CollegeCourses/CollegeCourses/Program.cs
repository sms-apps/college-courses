using CollegeCourses.Business;
using Ninject;

namespace CollegeCourses
{
    class Program
    {
        private static StandardKernel _kernel;

        static void Main(string[] args)
        {
            _kernel = new StandardKernel(new CollegeCoursesNinjectModule());

        }
    }
}
