using Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        public readonly Pet_DevExtremeContext _context;

        public CityController(Pet_DevExtremeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<City>>> Get()
        {
            return Ok(await _context.Cities.ToArrayAsync());
        }
    }
}
