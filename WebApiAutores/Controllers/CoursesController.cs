using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiAutores.DTOS;
using WebApiAutores.Entidades;
using WebApiAutores.Services;

namespace WebApiAutores.Controllers
{

    [ApiController]// decoramos el controlador con este atributo que me pemritira hacer validac automaticas respecto a data recibida
    [Route("api/courses")]
    public class CoursesController: ControllerBase
    {

        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        //[Authorize] 
        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(CourseCreacionDTO course)
        {
            
            try
            {
                _courseService.AddCourse(course);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(course);
        }

        [HttpGet("{Search}")]
        public async Task<ActionResult<IEnumerable<CourseDTO>>> GetCoursesByName(string Name)
        {
            try
            {
                var coursesResult = await _courseService.GetCoursesByName(Name);

                if (coursesResult.Any())
                {

                    return Ok(coursesResult);
                }
                return NotFound();


            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    " Error retrieving data from dtabase ");

            }




        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDTO>>> GetAllCourses()
        {
            var courses = await _courseService.GetAllCourses();
            if (courses == null)
            {
                return NotFound();
            }
            return Ok(courses);
        }

        //courseRepository


      


    }
}
