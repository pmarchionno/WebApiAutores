using WebApiAutores.DTOS;
using WebApiAutores.Entidades;
using Microsoft.EntityFrameworkCore;

namespace WebApiAutores.Repositories


{
    public class CourseRepository: ICourseRepository    

    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;

        }
        public void AddCourse(Course course)
        {
            if (course != null)
            {
                try
                {
                    _context.Courses.Add(course);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetCoursesByName(string Name)

        {
            IQueryable<Course> courses = _context.Courses;

            return await courses.Where(c => c.Name.Contains(Name)).ToListAsync();
        }


    }
}
