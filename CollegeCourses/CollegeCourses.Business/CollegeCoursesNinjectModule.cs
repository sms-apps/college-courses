using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeCourses.Business
{
    public class CollegeCoursesNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEngine>().To<Engine>();
        }
    }
}
