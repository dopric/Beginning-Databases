using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using BDData;
using BDMvcClient.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BDMvcClient.Controllers
{
    public class EmployeeController : Controller
    {
        readonly HttpClient _client;
        readonly IOptions<WebApiConfig> _config;
        readonly WebApiConfig _apiConfig;
        public EmployeeController(HttpClient client, IOptions<WebApiConfig> config)
        {
            this._config = config;
            this._client = client;
            _apiConfig = config.Value;
           
        }
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await _client.GetAsync(_apiConfig.EmployeeUrl);
            string stringData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
        };
            List<Employee> employees = JsonSerializer.Deserialize<List<Employee>>(stringData, options);
            return View(employees);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            HttpResponseMessage response = await _client.GetAsync($"{_apiConfig.EmployeeUrl}/{id}");
            var stringData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            Employee employee = JsonSerializer.Deserialize<Employee>(stringData, options);
            return View(employee);
        }
    }
}
