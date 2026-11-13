var builder = WebApplication.CreateBuilder(args);

// Service registration: enable MVC controllers and Razor views.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Conventional MVC routing: /Controller/Action/{id?}
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
