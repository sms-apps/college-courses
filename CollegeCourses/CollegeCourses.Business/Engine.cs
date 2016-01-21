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

            var courses = _mapper.ToCourses(classes);
            result.AddRange(courses
                .Where(c => string.IsNullOrWhiteSpace(c.PrerequisiteTitle))
                .Select(f => f.Title)
            );

            return result;
        }
    }
}