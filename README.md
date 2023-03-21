# ASP.NET 6 - API REST - Angular - CRUD

This applcation was made with:
- ASP.NET Core 6
- SQL Server 2019
- Without Controllers (Minimalist Views)
- Angular 15.2.2
- Angular Material 15.2.2

Required packages in Visual Studio:
- Microsoft.EntityFrameworkCore.SqlServer 7.0.0
- Microsoft.EntityFrameworkCore.Tools 7.0.0
- Automapper 12.0.0
- AutoMapper.Extensions.Microsoft.DependencyInjection 12.0.0

Required facilities in VS Code:
- npm install moment --save
- npm install @angular/material-moment-adapter@15.2.2

Use the following command line to add our database context to our project:
- In Visual Studio, find the "Tools" tab > NuGet Package Manager > Package Manager Console.
- And paste in the console -> Scaffold-DbContext "Server=(local); DataBase=db_angularapiCrud; Trusted_Connection=True; TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutPutDir Models