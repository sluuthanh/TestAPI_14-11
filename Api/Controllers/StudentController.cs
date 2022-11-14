using Api.Models;
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

        [HttpGet("GetCityDistric")]
        public async Task<ActionResult<List<CityDistrict>>> GetCityDistric()
        {
            return Ok(await _context.CityDistricts.ToArrayAsync());
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

        [HttpPost]
        public async Task<ActionResult<List<Student>>> Post(Student test)
        {
            _context.Students.Add(test);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<Student>> Put(Student test)
        {
            Student student =await _context.Students.FindAsync(test.SchedulerId);
            if (student == null)
            {
                return BadRequest("Not Found");
            }
            student.Name = test.Name;
            student.DoB = test.DoB;
            student.ClassStudent = test.ClassStudent;
            student.CityId = test.CityId;
            student.DistrictId = test.DistrictId;
            student.HinhAnh = test.HinhAnh;

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
