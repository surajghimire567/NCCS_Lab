# NCCS_Lab_MVC — Questions 11-20 (ASP.NET Core MVC)

One combined ASP.NET Core MVC project demonstrating Q11-Q20 together, since in
practice these all build up incrementally inside a single web application
(exactly how a lab/project is normally structured).

## How to run (on a machine with the .NET 8 SDK installed)
```
cd PartB_AspNetCoreMVC/NCCS_Lab_MVC
dotnet restore
dotnet ef database update      # creates nccs_lab.db (needs: dotnet tool install --global dotnet-ef)
dotnet run
```
Then open the URL shown in the console (e.g. https://localhost:5001) and use the
links on the Home page.

## Question → Code map

| Q | Topic | File(s) |
|---|---|---|
| 11 | Project structure, Program.cs, hosting model | `Program.cs`, `README_Q11_ProjectStructure.md` |
| 12 | Controller returning list to Razor view, foreach | `Controllers/ProductController.cs`, `Views/Product/Index.cshtml` |
| 13 | Razor syntax + Tag Helpers (asp-for, asp-action) | `Views/Employee/Register.cshtml` |
| 14 | Data Annotations + client/server validation | `Models/Employee.cs`, `Controllers/EmployeeController.cs` |
| 15 | Custom URL routing (`/employee/details/5`) | `Program.cs` (MapControllerRoute "employeeDetails"), `EmployeeController.Details()` |
| 16 | Web API Controller, GET/POST, JSON | `Controllers/Api/ProductsApiController.cs` |
| 17 | EF Core DbContext + CRUD for Book | `Data/AppDbContext.cs`, `Models/Book.cs`, `Controllers/BookController.cs` |
| 18 | Session State across two actions | `Controllers/SessionDemoController.cs` + its Views |
| 19 | ASP.NET Core Identity + [Authorize(Roles=...)] | `Program.cs` (AddDefaultIdentity), `Controllers/AdminController.cs` |
| 20 | Parameterized query vs SQL Injection | `Controllers/Api/SqlInjectionDemoController.cs` |

## Note on Q19 (Identity)
This demo registers Identity services and protects `AdminController` with
`[Authorize(Roles = "Admin")]`. To fully test login, scaffold Identity UI pages
(`dotnet aot add ... Microsoft.VisualStudio.Web.CodeGeneration.Design` then
`dotnet aspnet-codegenerator identity`) or add a minimal seed script that creates
a user and assigns the "Admin" role via `UserManager`/`RoleManager`. The
exam-relevant part — the `[Authorize(Roles = "Admin")]` attribute and Identity
service registration — is complete and ready to explain/demonstrate as-is.
