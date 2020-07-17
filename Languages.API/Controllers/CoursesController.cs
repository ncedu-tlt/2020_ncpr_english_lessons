using Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : Controller
    {
        [HttpGet]
        public ActionResult<List<Course>> GetCourses()
        {
            using (var db = new DataBaseContext())
            {
                List<Course> courses = db.Courses
                    .OrderBy(b => b.CourseId)
                    .ToList();

                return courses;
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Course> GetCourseItem(long id)
        {
            using (var db = new DataBaseContext())
            {
                Course course = db.Courses
                    .Where(l => l.CourseId == id)
                    .First();

                if (course == null)
                {
                    return NotFound();
                }

                course.NumberOfVisits += 1;
                UpdateCourseItem(course);
                return course;
            }
        }

        [HttpPost] 
        public ActionResult CreateCourseItem([FromBody] Course course)
        {
            using (var db = new DataBaseContext())
            {
                bool courseIsAlreadyExists = db.Courses
                    .Where(l => l.Title.Equals(course.Title))
                    .Count() > 0;

                if (courseIsAlreadyExists)
                {
                    return Conflict(); 
                }

                db.Add(course);
                db.SaveChanges();

                return Ok();
            }
        }

        [HttpPut] 
        public ActionResult UpdateCourseItem([FromBody] Course course)
        {
            using (var db = new DataBaseContext())
            {
                bool courseIsAlreadyExists = db.Courses
                    .Where(l => l.CourseId.Equals(course.CourseId))
                    .Count() > 0;

                if (courseIsAlreadyExists)
                {
                    db.Courses.Update(course);
                    db.SaveChanges();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }


            }
        }



        [HttpDelete] 
        public ActionResult DeleteCourseItem([FromBody] Course course)
        {
            using (var db = new DataBaseContext())
            {
                bool courseIsAlreadyExists = db.Courses
                    .Where(l => l.CourseId.Equals(course.CourseId))
                    .Count() > 0;

                if (courseIsAlreadyExists)
                {
                    db.Courses.Remove(course);
                    db.SaveChanges();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
        }

    }
}
