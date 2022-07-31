using WebApiAutores.DTOS;

namespace WebApiAutores.Services
{
    public interface ICourseService
    {
        public void AddCourse(CourseCreacionDTO course); //AddCourse

        public Task<IEnumerable<CourseDTO>> GetAllCourses();

        public Task<IEnumerable<CourseDTO>> GetCoursesByName(string Name);





    }
}
