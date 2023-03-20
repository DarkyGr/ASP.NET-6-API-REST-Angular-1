using AutoMapper;
using BackEndAPI.DTOs;
using BackEndAPI.Models;
using System.Globalization;

namespace BackEndAPI.Utilities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            #region Department
            CreateMap<Department, DepartmentDTO>().ReverseMap();    // Model to DTO and reverseMap
            #endregion

            #region Employee
            // Model to DTO
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(destination => 
                    destination.DepartmentName,
                    opt => opt.MapFrom(source => source.Department.DepartmentName)
                )
                .ForMember(destination =>
                    destination.ContractDate,
                    opt => opt.MapFrom(source => source.ContractDate.Value.ToString("dd/MM/yyyy"))
                );

            // DTO to Model
            CreateMap<EmployeeDTO, Employee>()
                .ForMember(destination => 
                    destination.Department,
                    opt => opt.Ignore()
                )
                .ForMember(destination =>
                    destination.ContractDate,
                    opt => opt.MapFrom(source => 
                        DateTime.ParseExact(source.ContractDate, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                );
            #endregion
        }
    }
}
