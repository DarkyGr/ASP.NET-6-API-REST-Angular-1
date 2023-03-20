namespace BackEndAPI.DTOs
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }

        public string? EmployeeName { get; set; }

        public int? DepartmentId { get; set; }

        public string? DepartmentName { get; set; }

        public int? Salary { get; set; }

        public string? ContractDate { get; set; }
    }
}
