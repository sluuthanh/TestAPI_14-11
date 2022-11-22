using DevExtreme.AspNet;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestClientDevExtreme.Models;

namespace TestClientDevExtreme.Controllers
{
    [Route("Location")]
    public class LocationController : Controller
    {
        private readonly string uri = "https://localhost:7255";

        private HttpClient client = new HttpClient();

        //public LocationController(HttpClient client)
        //{
        //    this.client = client;
        //}

        #region Province
        [HttpGet("GetProvincies")]
        public object GetProvincies(DataSourceLoadOptions loadOptions)
        {
            var result = new List<Province>();
            Task.Run(async () =>
            {
                var response = await client.GetAsync(uri + $"/location/province");
                var body = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<Province>>(body);
            }).Wait();

            return DataSourceLoader.Load((dynamic)result, loadOptions);
        }
        #endregion

        #region District
        [HttpGet("GetDistricts")]
        public object GetDistricts(DataSourceLoadOptions loadOptions)
        {
            var result = new DistrictNew();
            Task.Run(async () =>
            {
                var response = await client.GetAsync(uri + $"/location/district");
                var body = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<DistrictNew>(body);
            }).Wait();

            return DataSourceLoader.Load((dynamic)result, loadOptions);
        }

        [HttpGet("GetDistrictById")]
        public object GetDistrictById(DataSourceLoadOptions loadOptions, int _districtid)
        {
            var result = new DistrictNew();
            Task.Run(async () =>
            {
                var response = await client.GetAsync(uri + $"/location/district/" + _districtid.ToString());
                var body = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<DistrictNew>(body);
            }).Wait();

            return DataSourceLoader.Load((dynamic)result, loadOptions);
        }

        [HttpGet("GetDistrictsByProvinceId")]
        public object GetDistrictsByProvinceId(DataSourceLoadOptions loadOptions, long _provinceId)
        {
            var queryParams = Request.Query.ToDictionary(x => x.Key, x => x.Value);
            var result = new DistrictNew();
            Task.Run(async () =>
            {
                var response = await client.GetAsync(uri + $"/location/district/getlistbyprovince?provinceId=" + _provinceId.ToString());
                var body = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<DistrictNew>(body);
            }).Wait();

            return DataSourceLoader.Load((dynamic)result, loadOptions);
        }
        #endregion

        #region Ward

        [HttpGet("GetWards")]
        public object GetWards(DataSourceLoadOptions loadOptions)
        {
            var result = new Ward();
            Task.Run(async () =>
            {
                var response = await client.GetAsync(uri + $"/location/ward");
                var body = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<Ward>(body);
            }).Wait();

            return DataSourceLoader.Load((dynamic)result, loadOptions);
        }

        [HttpGet("GetWardById")]
        public object GetWardById(DataSourceLoadOptions loadOptions, int _wardid)
        {
            var result = new Ward();
            Task.Run(async () =>
            {
                var response = await client.GetAsync(uri + $"/location/ward/" + _wardid.ToString());
                var body = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<Ward>(body);
            }).Wait();

            return DataSourceLoader.Load((dynamic)result, loadOptions);
        }

        [HttpGet("GetWardsByDistrictId")]
        public object GetWardsByDistrictId(DataSourceLoadOptions loadOptions, int _districtid)
        {
            var result = new Ward();
            Task.Run(async () =>
            {
                var response = await client.GetAsync(uri + $"/location/ward/getbydistrict?districtId=" + _districtid.ToString());
                var body = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<Ward>(body);
            }).Wait();

            return DataSourceLoader.Load((dynamic)result, loadOptions);
        }
        #endregion

        //#region Quarter
        //[HttpGet("GetQuarters")]
        //public object GetQuarters(DataSourceLoadOptions loadOptions)
        //{
        //    var result = new Province();
        //    Task.Run(async () =>
        //    {
        //        var response = await client.GetAsync(uri + $"/location/quater");
        //        var body = await response.Content.ReadAsStringAsync();
        //        result = JsonConvert.DeserializeObject<Province>(body);
        //    }).Wait();

        //    return DataSourceLoader.Load((dynamic)result, loadOptions);
        //}

        //[HttpGet("GetQuarterById")]
        //public object GetQuarterById(DataSourceLoadOptions loadOptions, int _quarterid)
        //{
        //    var result = new Province();
        //    Task.Run(async () =>
        //    {
        //        var response = await client.GetAsync(uri + $"/location/quater/" + _quarterid.ToString());
        //        var body = await response.Content.ReadAsStringAsync();
        //        result = JsonConvert.DeserializeObject<Province>(body);
        //    }).Wait();

        //    return DataSourceLoader.Load((dynamic)result, loadOptions);
        //}

        //[HttpGet("GetQuartersByWardId")]
        //public object GetQuartersByWardId(DataSourceLoadOptions loadOptions, int _wardid)
        //{
        //    var result = new Province();
        //    Task.Run(async () =>
        //    {
        //        var response = await client.GetAsync(uri + $"/location/quater/getbyward?wardId=" + _wardid.ToString());
        //        var body = await response.Content.ReadAsStringAsync();
        //        result = JsonConvert.DeserializeObject<Province>(body);
        //    }).Wait();

        //    return DataSourceLoader.Load((dynamic)result, loadOptions);
        //}
        //#endregion
        public IActionResult Index()
        {
            return View();
        }
    }
}
