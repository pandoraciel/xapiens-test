using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using XapiensTest.Models;

namespace XapiensTest.Services
{
    public class XapiensTestService
    {
        public XapiensTestService()
        {

        }
        public async Task<List<Datum>> GetList()
        {
            var client = new HttpClient();
            var result = await client.GetAsync("https://reqres.in/api/users?per_page=12");
            if (result.IsSuccessStatusCode)
            {
                var deserializedObject = JsonConvert.DeserializeObject<ResponseData>(result.Content.ReadAsStringAsync().Result);
                return deserializedObject.data.ToList();
            }
            //client.Dispose();
            return null;
        }

        public async Task<Data> GetById(int id)
        {
            var client = new HttpClient();
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var url = string.Format($"https://reqres.in/api/users/{id}");
            var result = await client.GetAsync(url);
            if (result.IsSuccessStatusCode)
            {
                var deserializedObject = JsonConvert.DeserializeObject<ResponseObject>(result.Content.ReadAsStringAsync().Result);
                return deserializedObject.data;
            }
            return null;
        }

        public async Task<ResponseLoginSuccessOrFail> SignIn(string user, string pwd)
        {
            var client = new HttpClient();
            var url = string.Format($"https://reqres.in/api/login");
            var data = new
            {
                email = user,
                password = pwd
            };
            var result = await client.PostAsJsonAsync(url, data);

            var deserializedObject = JsonConvert.DeserializeObject<ResponseLoginSuccessOrFail>(result.Content.ReadAsStringAsync().Result);
            return deserializedObject;
        }
    }
}