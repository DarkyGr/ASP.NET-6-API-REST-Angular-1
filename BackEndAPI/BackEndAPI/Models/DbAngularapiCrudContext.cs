using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BackEndAPI.Models;

public partial class DbAngularapiCrudContext : DbContext
{
    public DbAngularapiCrudContext()
    {
    }

    public DbAngularapiCrudContext(DbContextOptions<DbAngularapiCrudContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__F9B8346D99E181BE");

            entity.ToTable("Department");

            entity.Property(e => e.DepartmentId).HasColumnName("departmentId");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdDate");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("departmentName");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__C134C9C1560F51F1");

            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeId).HasColumnName("employeeId");
            entity.Property(e => e.ContractDate)
                .HasColumnType("datetime")
                .HasColumnName("contractDate");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdDate");
            entity.Property(e => e.DepartmentId).HasColumnName("departmentId");
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("employeeName");
            entity.Property(e => e.Salary).HasColumnName("salary");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__Employee__depart__2A4B4B5E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
