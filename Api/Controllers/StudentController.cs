using Api.Models;
using Api.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public readonly Pet_DevExtremeContext _context;

        public StudentController(Pet_DevExtremeContext context)
        {
            _context = context;
        }

        [HttpGet("GetDistrict")]
        public async Task<ActionResult<List<District>>> GetDistrict()
        {
            return Ok(await _context.Districts.ToArrayAsync());
        }

        [HttpGet("GetDistrictByCity/{cityId}")]
        public async Task<ActionResult<List<CityDistrict>>> GetDistrictByCity(int cityId)
        {
            //var result = from cd in _context.CityDistricts join c in _context.Cities on cd.CityId equals c.Id
            //             select cd.District;
            var resultDistrict = from cd in _context.CityDistricts
                          where cd.CityId == cityId
                          select cd.District;
            return Ok(resultDistrict);
        }

        [HttpGet("GetCity")]
        public async Task<ActionResult<List<City>>> GetCity()
        {
            return Ok(await _context.Cities.ToArrayAsync());
        }

        [HttpGet("GetStudent")]
        public async Task<ActionResult<List<Student>>> GetStudent()
        {
            return Ok(await _context.Students.ToArrayAsync());
        }


        [HttpGet("GetClassDoB")]
        public async Task<ActionResult<List<dynamic>>> GetClassDoB()
        {
            var resultClassDistinct = (from s in _context.Students
                                 select new { s.ClassStudent  }).Distinct().ToList()  ;
            var resultDoBDistinct = (from s in _context.Students
                                     select new { s.DoB }).Distinct().ToList();
            return Ok(resultClassDistinct);
        }

        [HttpGet("Get/{id}")]
        public async Task<ActionResult<Student>> Get(int id)
        {
            Student student =await _context.Students.FindAsync(id);
            if (student == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(student);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<Student>> Post(ViewStudent test)
        {
            Student student = new Student();
            student.Name = test.Name;
            student.DoB = test.DoB;
            student.ClassStudent = test.ClassStudent;
            student.CityId = test.CityId;
            student.DistrictId = test.DistrictId;
            student.District = _context.Districts.Find(test.DistrictId);
            student.City = _context.Cities.Find(test.CityId);
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("Put")]
        public async Task<ActionResult<Student>> Put(ViewStudent test)
        {

            Student student = await _context.Students.FindAsync(test.SchedulerId);
            if (student == null)
            {
                return BadRequest("Not Found");
            }
            student.Name = test.Name;
            student.DoB = test.DoB;
            student.ClassStudent = test.ClassStudent;
            student.CityId = test.CityId;
            student.DistrictId = test.DistrictId;

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<List<Student>>> Delete(int id)
        {
            var delete = await _context.Students.FindAsync(id);
            if (delete == null)
            {
                return BadRequest("Not Found");
            }
            _context.Students.Remove(delete);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
