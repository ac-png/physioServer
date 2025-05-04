using Microsoft.EntityFrameworkCore;
using FlexiCareManager.Data;
using FlexiCareManager.Seeds;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddDbContext<FlexiCareManagerContext>(options =>
//     options.UseSqlite(builder.Configuration.GetConnectionString("FlexiCareManagerContext") ?? throw new InvalidOperationException("Connection string 'FlexiCareManagerContext' not found.")));

var connection = String.Empty;

builder.Configuration.AddEnvironmentVariables().AddJsonFile("appsettings.Development.json");
connection = builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");

builder.Services.AddDbContext<FlexiCareManagerContext>(options =>
    options.UseSqlServer(connection));

builder.Services
    .AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<FlexiCareManagerContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer((document, context, cancellationToken) =>
    {
        document.Info.Contact = new OpenApiContact
        {
            Name = "FlexiCare Support",
            Email = "support@flexicare.ie"
        };
        return Task.CompletedTask;
    });
});
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();
app.MapIdentityApi<IdentityUser>();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages();

app.MapOpenApi();
app.UseSwaggerUi(options =>
{
    options.DocumentPath = "/openapi/v1.json";
});

app.MapGet("/hello/{name}", (string name) => $"Hello, {name}!")
    .WithSummary("Get a personalized greeting")
    .WithDescription("This endpoint returns a personalized greeting based on the provided name.")
    .WithTags("Greetings");

app.Run();
