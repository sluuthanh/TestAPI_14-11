using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TestClientDevExtreme.Models;
using TestClientDevExtreme.Models.DTO;

namespace TestClientDevExtreme.Controllers
{
    [Route("[controller]")]
    public class TestsController : Controller
    {
        private readonly string uri = "https://localhost:7255/Student";


        private HttpClient client = new HttpClient();

        [HttpPost("GetStudent")]
        public object GetStudent(DataSourceLoadOptions loadOptions, string searchOptions)
        {
            List<Student> result = new List<Student>();
            ClassSearchDTO b = JsonConvert.DeserializeObject <ClassSearchDTO>(searchOptions);
            if (searchOptions == null || searchOptions == "{}")
            {
                ClassSearchDTO a = new ClassSearchDTO("","");
                StringContent content = new StringContent(System.Text.Json.JsonSerializer.Serialize(a), Encoding.UTF8, "application/json");
                Task.Run(async () => {
                    var response = await client.PostAsync("https://localhost:7255/Student/PostStudent", content);
                    var body = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<List<Student>>(body);
                }).Wait();
                return DataSourceLoader.Load(result, loadOptions);
            }
            else
            {
                //ClassSearchDTO a = new ClassSearchDTO();
                //StringContent content = new StringContent(System.Text.Json.JsonSerializer.Serialize(a), Encoding.UTF8, "application/json");
                StringContent content = new StringContent(searchOptions, Encoding.UTF8, "application/json");
                Task.Run(async () => {
                    var response = await client.PostAsync("https://localhost:7255/Student/PostStudent", content);
                    var body = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<List<Student>>(body);
                }).Wait();
                return DataSourceLoader.Load((dynamic)result, loadOptions);
            }
           
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


        [HttpGet("GetClassStudent")]
        public object GetClassStudent(DataSourceLoadOptions loadOptions)
        {
            List<ClassSearchDTO> result = null;
            Task.Run(async () => {
                var response = await client.GetAsync(uri + "/GetClassStudent");
                var body = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<ClassSearchDTO>>(body);
            }).Wait();
            return DataSourceLoader.Load((dynamic)result, loadOptions);
        }

        [HttpGet("GetYearDob")]
        public object GetYearDob(DataSourceLoadOptions loadOptions)
        {
            List<ClassSearchDTO> result = null;
            Task.Run(async () => {
                var response = await client.GetAsync(uri + "/GetYearDob");
                var body = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<ClassSearchDTO>>(body);
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

        [HttpGet("GetDistrictByCityData")]
        public object GetDistrictByCityData(DataSourceLoadOptions loadOptions)
        {
            List<CityDistrict> result = new List<CityDistrict>();
            Task.Run(async () => {
                var response = await client.GetAsync(uri + "/GetDistrictByCityData");
                var body = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<CityDistrict>>(body);
            }).Wait();
            return Json(result);
        }

        [HttpPost("Create")]
        public object Insert(string search)
        {
            Student inputStudent = JsonConvert.DeserializeObject<Student>(search);
            Student result = null;
            StringContent content = new StringContent(System.Text.Json.JsonSerializer.Serialize(inputStudent), Encoding.UTF8, "application/json");
            //StringContent content = new StringContent(search, Encoding.UTF8, "application/json");
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


        [HttpPost("Update")]
        public object Update(List<Student> lstModel)
        {
            StringContent content = new StringContent(System.Text.Json.JsonSerializer.Serialize(lstModel), Encoding.UTF8, "application/json");
            var result = new ResponseMessage();
            Task.Run(async () =>
            {

                var response = await client.PutAsync(uri + "/updateSelected", content);
                var body = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<ResponseMessage>(body);
            }).Wait();
            return result;
        }


        [HttpGet("Delete/{id}")]
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


        [HttpPost("DeleteSelection")]
        public object DeleteSelection(List<int> lstId)
        {
            StringContent content = new StringContent(System.Text.Json.JsonSerializer.Serialize(lstId), Encoding.UTF8, "application/json");
            Student result = null;
            Task.Run(async () =>
            {

                var response = await client.PostAsync(uri + $"/DeleteSelection", content);
                var body = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<Student>(body);
            }).Wait();
            return result;
        }
    }
}
