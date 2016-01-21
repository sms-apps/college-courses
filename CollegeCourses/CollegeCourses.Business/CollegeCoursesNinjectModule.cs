using Ninject.Modules;

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
