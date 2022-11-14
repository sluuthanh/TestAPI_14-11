using Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        public readonly Pet_DevExtremeContext _context;

        public DistrictController(Pet_DevExtremeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<District>>> Get()
        {
            return Ok(await _context.Districts.ToArrayAsync());
        }
    }
}
