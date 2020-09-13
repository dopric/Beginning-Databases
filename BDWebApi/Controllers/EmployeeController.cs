using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BDData;
using BDWebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BDWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        readonly IRepository<Employee> _repository;
        public EmployeeController(IRepository<Employee> repository)
        {
            this._repository = repository;
        }
        [HttpGet]
        public List<Employee> GetEmployees()
        {
            return _repository.GetAll().ToList();
        }

        [HttpGet("{id}")]
        public Employee GetEmployee(int id)
        {
            return _repository.GetById(id);
        }

        [HttpPost]
        public void Post(Employee employee)
        {
            // todo
        }

        [HttpPut("{id}")]
        public void Update(int id, Employee data)
        {
            // TODO
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Remove(id);
        }
    }
}
