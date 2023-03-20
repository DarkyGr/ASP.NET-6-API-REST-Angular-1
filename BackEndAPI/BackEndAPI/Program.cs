using Microsoft.EntityFrameworkCore;
using BackEndAPI.Models;

using BackEndAPI.Services.Contract;
using BackEndAPI.Services.Implementation;

using AutoMapper;
using BackEndAPI.DTOs;
using BackEndAPI.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add database context
builder.Services.AddDbContext<DbAngularapiCrudContext>(option => {
    option.UseSqlServer(builder.Configuration.GetConnectionString("SQLString"));
});

// Add Services
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

// Add AutoMapper Profile
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Add New Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("NewPolicy", app =>{
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();        
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region API REST Requests
app.MapGet("/department/list", async (
    IDepartmentService _departmentService,
    IMapper _mapper
    ) =>
{
    List<Department> departmentList = await _departmentService.GetDepartmentList();     // Get Department list of Model
    List<DepartmentDTO> departmentDtoList = _mapper.Map<List<DepartmentDTO>>(departmentList);   // Convert List to DTO

    if (departmentDtoList.Count > 0)    // check that the list isn't empty
    {
        return Results.Ok(departmentDtoList);
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapGet("/employee/list", async (
    IEmployeeService _employeeService,
    IMapper _mapper
    ) =>
{
    var employeeList = await _employeeService.GetEmployeeList();     // Get Department list of Model
    var employeeDtoList = _mapper.Map<List<EmployeeDTO>>(employeeList);   // Convert List to DTO

    if (employeeDtoList.Count > 0)    // check that the list isn't empty
    {
        return Results.Ok(employeeDtoList);
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapPost("/employee/save", async (
    EmployeeDTO model,
    IEmployeeService _employeeService,
    IMapper _mapper
    ) => {

        var _employee = _mapper.Map<Employee>(model);
        var _employeeCreated = await _employeeService.AddEmployee(_employee);

        if (_employeeCreated.EmployeeId != 0)
        {
            return Results.Ok(_mapper.Map<EmployeeDTO>(_employeeCreated));
        }
        else
        {
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
        }
    });

app.MapPut("/employee/update/{employeeId}", async(
    int employeeId,
    EmployeeDTO model,
    IEmployeeService _employeeService,
    IMapper _mapper
    ) => {
        var _founded = await _employeeService.GetEmployeeById(employeeId);

        if (_founded is null)
        {
            return Results.NotFound();   
        }

        var _employee = _mapper.Map<Employee>(model);
        
        _founded.EmployeeName = _employee.EmployeeName;
        _founded.DepartmentId = _employee.DepartmentId;
        _founded.Salary = _employee.Salary;
        _founded.CreatedDate = _employee.CreatedDate;

        var response = await _employeeService.UpdateEmployee(_founded);

        if (response)
        {
            return Results.Ok(_mapper.Map<EmployeeDTO>(_founded));
        }
        else {
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
        }

    });

app.MapDelete("/employee/delete/{employeeId}", async (
    int employeeId,
    IEmployeeService _employeeService    
    ) => {

        var _founded = await _employeeService.GetEmployeeById(employeeId);

        if (_founded is null)
        {
            return Results.NotFound();
        }

        var response = await _employeeService.DeleteEmployee(_founded);

        if (response)
        {
            return Results.Ok();
        }
        else
        {
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
        }
    });

#endregion

// Active Cors
app.UseCors("NewPolicy");

app.Run();