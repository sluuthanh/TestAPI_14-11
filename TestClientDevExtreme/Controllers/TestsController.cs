using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TestClientDevExtreme.Models;

namespace TestClientDevExtreme.Controllers
{
    [Route("[controller]")]
    public class TestsController : Controller
    {
        private readonly string uri = "https://localhost:7255/Student";


        private HttpClient client = new HttpClient();

        [HttpGet("GetStudent")]
        public object GetStudent(DataSourceLoadOptions loadOptions)
        {
            List<Student> result = null;
            Task.Run(async () => {
                var response = await client.GetAsync(uri + "/GetStudent");
                var body = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<Student>>(body);
            }).Wait();
            return DataSourceLoader.Load((dynamic)result, loadOptions);
        }

        [HttpGet("GetCity")]
        public object GetCity(DataSourceLoadOptions loadOptions)
        {
            List<City> result = null;
            Task.Run(async () =>
            {
                var response = await client.GetAsync(uri + "/GetCity");
                var body = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<City>>(body);
            }).Wait();
            return DataSourceLoader.Load((dynamic)result, loadOptions);
        }


        [HttpGet("GetDistrict")]
        public object GetDistrict(DataSourceLoadOptions loadOptions)
        {
            List<District> result = null;
            Task.Run(async () => {
                var response = await client.GetAsync(uri + "/GetDistrict");
                var body = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<District>>(body);
            }).Wait();
            return DataSourceLoader.Load((dynamic)result, loadOptions);
        }


        [HttpGet("GetDistrictByCity")]
        public object GetCityDistrict(DataSourceLoadOptions loadOptions,int cityId)
        {
            List<District> result = null;
            Task.Run(async () => {
                var response = await client.GetAsync(uri + $"/GetDistrictByCity/{cityId}");
                var body = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<District>>(body);
            }).Wait();
            return DataSourceLoader.Load((dynamic)result, loadOptions);
        }

        [HttpPost("Create")]
        public object Insert(string search)
        {
            Student result = null;
            StringContent content = new StringContent(search, Encoding.UTF8, "application/json");
            Task.Run(async () =>
            {
                var response = await client.PostAsync(uri + "/Create", content);
                var body = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<Student>(body);
            }).Wait();
            return Json(result);
        }


        [HttpPost("UpdateStudent")]
        public object UpdateStudent(string search)
        {
            Student result = null;
            //result = null;
            StringContent content = new StringContent(search, Encoding.UTF8, "application/json");
            Task.Run(async () =>
            {
                var response = await client.PutAsync(uri + "/Put", content);
                var body = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<Student>(body);
            }).Wait();
            return result;
        }


        [HttpPost("Delete")]
        public object Delete(int id)
        {
            Student result = null;
            //result = null;
            Task.Run(async () =>
            {
                var response = await client.DeleteAsync(uri + $"/Delete/{id}");
                var body = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<Student>(body);
            }).Wait();
            return result;
        }

    }
}
