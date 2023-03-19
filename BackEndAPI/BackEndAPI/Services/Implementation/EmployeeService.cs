using Microsoft.EntityFrameworkCore;
using BackEndAPI.Models;
using BackEndAPI.Services.Contract;

namespace BackEndAPI.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private DbAngularapiCrudContext _dbContext;

        public EmployeeService(DbAngularapiCrudContext dbContext) { 
            _dbContext = dbContext;
        }

        // Method to Get Employee List
        public async Task<List<Employee>> GetEmployeeList()
        {
            try
            {
                List<Employee> list = new List<Employee>();

                list = await _dbContext.Employees.Include(dpt => dpt.DepartmentId).ToListAsync();

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Method to Get Employee by id
        public async Task<Employee> GetEmployeeById(int employeeId)
        {
            try
            {
                Employee? employee = new Employee();    // Can to return null with "?"

                employee = await _dbContext.Employees.Include(dpt => dpt.DepartmentId)
                    .Where(e => e.EmployeeId == employeeId).FirstOrDefaultAsync();

                return employee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Method to Add Employee
        public async Task<Employee> AddEmployee(Employee model)
        {
            try
            {
                _dbContext.Employees.Add(model);
                await _dbContext.SaveChangesAsync();
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Method to Update Employee
        public async Task<bool> UpdateEmployee(Employee model)
        {
            try
            {
                _dbContext.Employees.Update(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Method to Delete Employee
        public async Task<bool> DeleteEmployee(Employee model)
        {
            try
            {
                _dbContext.Employees.Remove(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
