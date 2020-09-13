using BDData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BDWebApi.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        readonly AppDbContext _dbContext;
        public EmployeeRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public void Add(Employee entity)
        {
            _dbContext.Employees.Add(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Employee> GetAll()
        {
            return _dbContext.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            return _dbContext.Employees.Find(id);
        }

        public void Remove(int id)
        {
            var employee = GetById(id);
            // TODO exists employee?
            _dbContext.Employees.Remove(employee);
            _dbContext.SaveChanges();
        }

        public void Update(Employee entity)
        {
            var employee = GetById(entity.EmployeeID);
            // TODO employee exists?
            _dbContext.Employees.Update(employee);
            _dbContext.SaveChanges();

        }
    }
}
