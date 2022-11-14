using Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class CityDistrictController : ControllerBase
    {
        public readonly Pet_DevExtremeContext _context;

        public CityDistrictController(Pet_DevExtremeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<CityDistrict>>> Get()
        {
            return Ok(await _context.CityDistricts.ToArrayAsync());
        }
    }
}
