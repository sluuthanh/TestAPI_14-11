using Api.Models;
using Api.Models.ViewDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Globalization;

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

        [HttpGet("GetDistrictByCityData")]
        public async Task<ActionResult<List<CityDistrict>>> GetDistrictByCityData()
        {
            List<CityDistrict> cityDistricts  = _context.CityDistricts.Include(c=>c.City).Include(d=>d.District).ToList();
            string json = JsonConvert.SerializeObject(cityDistricts, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Ok(json);
        }

        [HttpGet("GetCity")]
        public async Task<ActionResult<List<City>>> GetCity()
        {
            return Ok(await _context.Cities.ToArrayAsync());
        }

        [HttpPost("PostStudent")]
        public async Task<ActionResult<List<Student>>> PostStudent( ClassSearchDTO searchOptions)
        {

            if (searchOptions.ClassStudent =="" && searchOptions.Year == "")
            {
               return Ok(await _context.Students.ToArrayAsync());
            }
            else if(searchOptions.ClassStudent != "" && searchOptions.Year != "")
            {
                var students = _context.Students.Where(s => s.ClassStudent.Equals(searchOptions.ClassStudent) && s.DoB.Value.Year.ToString().Equals(searchOptions.Year)).ToArray();
                return Ok(students);
            }
            else
            {
                var students = _context.Students.Where(s => s.ClassStudent.Equals(searchOptions.ClassStudent) || s.DoB.Value.Year.ToString().Equals(searchOptions.Year)).ToArray();
                return Ok(students);
            }
        }


        [HttpGet("GetClassStudent")]
        public async Task<ActionResult<List<dynamic>>> GetClassStudent()    
        {
            var resultClassDistinct = (from s in _context.Students
                                       select new { s.ClassStudent }).Distinct().ToList();
            return Ok(resultClassDistinct);
        }

        [HttpGet("GetYearDoB")]
        public async Task<ActionResult<List<dynamic>>> GetYearDoB()
        {
            DateTime year;
            var resultDoBDistinct = ((from s in _context.Students
                                      select new { year = s.DoB.GetValueOrDefault().ToString("yyyy") }).ToList()).Distinct();
            return Ok(resultDoBDistinct);
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
            if (test.ClassStudent != null)
            {
                student.ClassStudent = test.ClassStudent;
            }
            if(test.DistrictId != null )
            {
                student.DistrictId = test.DistrictId;
                student.District = _context.Districts.Find(test.DistrictId);
            }
            if (test.CityId != null)
            {
                student.CityId = test.CityId;
                student.City = _context.Cities.Find(test.CityId);
            }
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
            student.District = _context.Districts.Find(test.DistrictId);
            student.City = _context.Cities.Find(test.CityId);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("updateSelected")]
        public async Task<ActionResult<List<Student>>> updateSelected(List<Student> lstModel)
        {
          
            foreach (var test in lstModel)
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
                student.District = _context.Districts.Find(test.DistrictId);
                student.City = _context.Cities.Find(test.CityId);
                await _context.SaveChangesAsync();
            }
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

        [HttpPost("DeleteSelection")]
        public async Task<ActionResult<List<Student>>> DeleteSelection(List<int> listId)
        {
            foreach (var idDelete in listId)
            {
                Student studentDelete = await _context.Students.FindAsync(idDelete);
                if (studentDelete == null)
                {
                    return BadRequest("Not Found");
                }
                _context.Students.Remove(studentDelete);
            }
                await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
