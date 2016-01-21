namespace CollegeCourses.Models
{
    public class Course
    {
        public string PrerequisiteTitle { get; set; }
        public Course PrerequisiteCourse { get; set; }
        public string Title { get; set; }
    }
}