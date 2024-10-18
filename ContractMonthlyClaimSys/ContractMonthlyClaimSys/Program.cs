using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ContractMonthlyClaimSys.Data;
using ContractMonthlyClaimSys.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure Entity Framework Core with SQL Server.
builder.Services.AddDbContext<ClaimDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add custom services for business logic and data access.
builder.Services.AddScoped<IClaimService, ClaimService>();

// Build the application.
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // Enforce HTTPS security.
}

app.UseHttpsRedirection(); // Redirect HTTP requests to HTTPS.
app.UseStaticFiles(); // Serve static files (like CSS, JavaScript, images).

app.UseRouting(); // Enable routing middleware.

app.UseAuthorization(); // Use authorization middleware.

// Map controller routes.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Run the application.
app.Run();
