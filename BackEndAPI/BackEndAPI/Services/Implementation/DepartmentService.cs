using Microsoft.EntityFrameworkCore;
using BackEndAPI.Models;
using BackEndAPI.Services.Contract;

namespace BackEndAPI.Services.Implementation
{
    public class DepartmentService : IDepartmentService
    {
        private DbAngularapiCrudContext _dbContext;

        public DepartmentService(DbAngularapiCrudContext dbContext) { 
            _dbContext = dbContext;
        }

        // Method to Get Department List
        public async Task<List<Department>> GetDepartmentList()
        {
            try { 
                List<Department> list = new List<Department>();

                list = await _dbContext.Departments.ToListAsync();

                return list;
            }catch (Exception ex) {
                throw ex;
            }
        }
    }
}
