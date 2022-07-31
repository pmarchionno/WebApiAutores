using WebApiAutores.Entidades;

namespace WebApiAutores.Repositories
{
    public interface ICourseRepository
    {

        public void AddCourse(Course course);

        public Task<IEnumerable<Course>> GetAllCourses();

        public Task<IEnumerable<Course>> GetCoursesByName(string Name);


    }
}
