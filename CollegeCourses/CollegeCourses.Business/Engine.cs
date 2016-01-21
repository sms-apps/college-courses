using System.Collections.Generic;

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

            var courses = _mapper.ToCourses(classes);

            return result;
        }
    }
}