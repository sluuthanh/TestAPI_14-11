using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        public readonly Pet_DevExtremeContext _context;

        public LocationController(Pet_DevExtremeContext context)
        {
            _context = context;
        }

        #region Province
        [HttpGet]
        [Route("province")]
        public async Task<ActionResult<List<Province>>> GetProvinceAll()
        {
            return Ok(await _context.Provinces.ToArrayAsync());
        }
        [HttpGet]
        [Route("province/{provinceId}")]
        public async Task<ActionResult<Province>> GetProvinceById(int provinceId)
        {
            Province province = await _context.Provinces.FindAsync(provinceId);
            if (province == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(province);
        }

        #endregion
        #region District
        [HttpGet]
        [Route("district")]
        public async Task<ActionResult<List<DistrictNew>>> GetAllDistrict()
        {
            return Ok(await _context.DistrictNews.ToArrayAsync());

        }
        [HttpGet]
        [Route("district/{districtId}")]
        public async Task<ActionResult<DistrictNew>> GetDistrictById(int districtId)
        {
            DistrictNew district = await _context.DistrictNews.FindAsync(districtId);
            if (district == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(district);

        }
        [HttpGet]
        [Route("district/getlistbyprovince")]
        public async Task<ActionResult<List<DistrictNew>>> GetDistrictByProvince(int provinceId)
        {
            List<DistrictNew> districtNews = _context.DistrictNews.Where(d => d.ProvinceId == provinceId).ToList();
            if (districtNews.Count() > 0)
            {
                return Ok(districtNews);
            }
            return BadRequest("Not Found");
        }
        #endregion

        #region Ward
        [HttpGet]
        [Route("ward")]
        public async Task<ActionResult<List<Ward>>> GetAllWard()
        {
            return Ok(await _context.Wards.ToArrayAsync());
        }
        [HttpGet]
        [Route("ward/{wardId}")]
        public async Task<ActionResult<Ward>> GetWardById(int wardId)
        {
            Ward ward = await _context.Wards.FindAsync(wardId);
            if (ward == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(ward);

        }
        [HttpGet]
        [Route("ward/getbydistrict")]
        public async Task<ActionResult<List<Ward>>> GetWardByDistrict(int districtId)
        {
            List<Ward> wards = _context.Wards.Where(d => d.DistrictId == districtId).ToList();
            if (wards.Count() > 0)
            {
                return Ok(wards);
            }
            return BadRequest("Not Found");
        }
        #endregion

        //#region Quarter
        //[HttpGet]
        //[Route("quater")]
        //public async Task<ActionResult<List<DistrictNew>>> GetAllQuarter()
        //{
           
        //}
        //[HttpGet]
        //[Route("quater/{quaterId}")]
        //public async Task<ActionResult<List<DistrictNew>>> GetQuarterById(int quaterId)
        //{
           

        //}
        //[HttpGet]
        //[Route("quater/getbyward")]
        //public async Task<ActionResult<List<DistrictNew>>> GetQuarterByWard(int wardId)
        //{
         
        //}
        //[HttpPost]
        //[Route("quater/insert")]
        //public async Task<ActionResult<List<DistrictNew>>> InsertQuarterById(QuarterModel model)
        //{
          
        //}
        //[HttpPut]
        //[Route("quater/update")]
        //public async Task<ActionResult<List<DistrictNew>>> UpdateQuarterById(QuarterModel model)
        //{
           
        //}
        //[HttpDelete]
        //[Route("quater/delete")]
        //public async Task<ActionResult<List<DistrictNew>>> DeleteQuarterById(int quarterId)
        //{
           
        //}
        //#endregion
    }
}
