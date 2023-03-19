using System;
using System.Collections.Generic;

namespace BackEndAPI.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string? DepartmentName { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
