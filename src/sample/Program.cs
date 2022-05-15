using sample.Database;
using Microsoft.EntityFrameworkCore;
using BetterHealthChecks.EntityFrameworkMappingHealthCheck;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var dbConnectionString = builder.Configuration.GetValue<string>("DbConnectionString");
builder.Services.AddDbContext<SampleDbContext>(options => options.UseSqlServer(dbConnectionString));

builder.Services
    .AddHealthChecks()
    .AddEntityFrameworkMappingCheck<SampleDbContext>(options =>
    {
        options.HealthCheckName = "SampleDbContext Health Check.";
        options.Tags = new[] { "database", "entity framework" };
    });

var app = builder.Build();

app.MapHealthChecks("/health");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
