using BackEndAPI.Models;

namespace BackEndAPI.Services.Contract
{
    public interface IEmployeeService
    {
        // Method to Get Employee List
        Task<List<Employee>> GetEmployeeList();

        // Method to Get Employee by id
        Task<Employee> GetEmployeeById(int employeeId);

        // Method to Add Employee
        Task<Employee> AddEmployee(Employee model);

        // Method to Update Employee
        Task<bool> UpdateEmployee(Employee model);

        // Method to Delete Employee
        Task<bool> DeleteEmployee(Employee model);
    }
}
