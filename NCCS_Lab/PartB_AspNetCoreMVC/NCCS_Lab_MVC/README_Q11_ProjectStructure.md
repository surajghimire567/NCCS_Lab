# Q11: ASP.NET Core MVC Project Structure Explanation

Created conceptually via: `dotnet new mvc -o NCCS_Lab_MVC`

## Program.cs
- Single entry point (replaces old `Program.cs` + `Startup.cs` combo).
- `WebApplication.CreateBuilder(args)` sets up configuration, logging, DI container.
- **Service registration** (`builder.Services.Add...`) = old `ConfigureServices()`.
  - `AddControllersWithViews()` → enables MVC pattern.
  - `AddDbContext<AppDbContext>()` → EF Core (Q17).
  - `AddDefaultIdentity<IdentityUser>()` → Identity auth (Q19).
  - `AddSession()` → session state (Q18).
- **HTTP pipeline** (`app.Use...`, `app.Map...`) = old `Configure()`.
  - Order matters: `UseRouting()` → `UseSession()` → `UseAuthentication()` → `UseAuthorization()` → `MapControllerRoute()`.

## "Startup configuration" (merged into Program.cs in .NET 6+)
- Older ASP.NET Core (2.x/3.x) split this into a separate `Startup.cs` with
  `ConfigureServices(IServiceCollection)` and `Configure(IApplicationBuilder)`.
- .NET 6+ "minimal hosting model" merges both into `Program.cs` using top-level statements — less boilerplate, same two responsibilities (register services, then build the pipeline).

## Default project folder structure
| Folder | Purpose |
|---|---|
| `Controllers/` | Handles HTTP requests, talks to models, picks a view (`HomeController`, `ProductController`...) |
| `Models/` | Data/entity classes (`Product`, `Employee`, `Book`) |
| `Views/<ControllerName>/` | `.cshtml` Razor pages matching each controller's actions |
| `Views/Shared/` | `_Layout.cshtml` and other views shared across controllers |
| `Data/` | `DbContext` classes (EF Core) |
| `wwwroot/` | Static files served directly: CSS, JS, images |
| `appsettings.json` | Configuration (connection strings, logging levels) |
| `Controllers/Api/` | Attribute-routed Web API controllers (no Views needed — return JSON) |

## Convention over configuration
MVC finds `Views/{Controller}/{Action}.cshtml` automatically by naming convention — e.g. `ProductController.Index()` → `Views/Product/Index.cshtml` — no manual wiring required.
