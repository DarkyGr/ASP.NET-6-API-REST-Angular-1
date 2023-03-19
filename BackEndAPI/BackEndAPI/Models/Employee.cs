using System;
using System.Collections.Generic;

namespace BackEndAPI.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? EmployeeName { get; set; }

    public int? DepartmentId { get; set; }

    public int? Salary { get; set; }

    public DateTime? ContractDate { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual Department? Department { get; set; }
}
