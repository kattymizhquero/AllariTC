using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using PayRoll.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connection = new SqliteConnection("DataSource=:memory:");
connection.Open();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connection));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Payroll}/{action=Employee}/{id?}");

app.Run();
