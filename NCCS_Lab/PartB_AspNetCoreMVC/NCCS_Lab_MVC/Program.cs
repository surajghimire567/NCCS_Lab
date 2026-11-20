using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NCCS_Lab_MVC.Data;

// Q11: WebApplication.CreateBuilder replaces the old Startup.cs (ConfigureServices + Configure).
// Everything — services (DI container registrations) and the HTTP pipeline — lives in this one file.
var builder = WebApplication.CreateBuilder(args);

// ---- Register services (equivalent of old Startup.ConfigureServices) ----

// MVC: Controllers + Views
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Q17: EF Core DbContext using SQLite (file-based, needs no external DB server)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Q19: ASP.NET Core Identity (authentication + role-based authorization)
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

// Q18: Session state (server-side state management on stateless HTTP)
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
});

var app = builder.Build();

// Create the SQLite schema for the lab demo when the database is new.
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();

    db.Database.ExecuteSqlRaw("""
        CREATE TABLE IF NOT EXISTS Users (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Username TEXT NOT NULL UNIQUE
        );
        INSERT OR IGNORE INTO Users (Username) VALUES ('alice');
        INSERT OR IGNORE INTO Users (Username) VALUES ('bob');
        """);

    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
    }

    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
    const string adminEmail = "admin@localhost";
    var admin = await userManager.FindByEmailAsync(adminEmail);
    if (admin == null)
    {
        admin = new IdentityUser
        {
            UserName = adminEmail,
            Email = adminEmail,
            EmailConfirmed = true
        };
        await userManager.CreateAsync(admin, "Admin123!");
    }

    if (!await userManager.IsInRoleAsync(admin, "Admin"))
    {
        await userManager.AddToRoleAsync(admin, "Admin");
    }
}

// ---- HTTP request pipeline (equivalent of old Startup.Configure) ----

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();          // must come after UseRouting, before UseAuthorization
app.UseAuthentication();   // Q19: who is the user?
app.UseAuthorization();    // Q19: what are they allowed to do?

// Q15: Custom route — matches BEFORE the default convention route,
// so /staff -> EmployeeController.Staff()
app.MapControllerRoute(
    name: "staff",
    pattern: "staff",
    defaults: new { controller = "Employee", action = "Staff" });

// Default conventional route: /{Controller}/{Action}/{id?}
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

// Q16/Q17/Q20: attribute-routed API controllers (api/[controller]/...)
app.MapControllers();

app.Run();
