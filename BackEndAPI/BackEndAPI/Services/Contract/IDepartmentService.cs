using BackEndAPI.Models;

namespace BackEndAPI.Services.Contract
{
    public interface IDepartmentService
    {
        // Method to Get Department List
        Task<List<Department>> GetDepartmentList();
    }
}
