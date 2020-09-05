using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BDData;
using Microsoft.AspNetCore.Mvc;

namespace BDAspCoreMvc.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly AppDbContext _dbContext;
        public EmployeesController(AppDbContext db)
        {
            _dbContext = db;
        }
        public IActionResult Index()
        {
            var employees = (from e in _dbContext.Employees
                             orderby e.EmployeeID
                             select e).ToList();
            return View(employees);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var employee = await _dbContext.Employees.FindAsync(id);
            if (employee == null)
            {
                return BadRequest();
            }
            else
            {
                return View(employee);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _dbContext.Employees.Find(id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            _dbContext.Employees.Update(employee);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var employee = _dbContext.Employees.Find(id);
            return View(employee);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _dbContext.Employees.Add(model);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(Employee model)
        {
            var emp = _dbContext.Employees.Find(model.EmployeeID);
            // should check if entry exists
            _dbContext.Employees.Remove(emp);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
