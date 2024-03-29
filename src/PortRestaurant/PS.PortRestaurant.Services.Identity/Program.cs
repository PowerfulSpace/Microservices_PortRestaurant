using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PS.PortRestaurant.Services.Identity;
using PS.PortRestaurant.Services.Identity.DbContexts;
using PS.PortRestaurant.Services.Identity.Initializer;
using PS.PortRestaurant.Services.Identity.Models;
using PS.PortRestaurant.Services.Identity.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services
    .AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

var builderIdentityServer = builder.Services.AddIdentityServer(options =>
{
    options.Events.RaiseErrorEvents = true;
    options.Events.RaiseInformationEvents = true;
    options.Events.RaiseFailureEvents = true;
    options.Events.RaiseSuccessEvents = true;
    options.EmitStaticAudienceClaim = true;
})
    .AddInMemoryIdentityResources(SD.IdentityResources)
    .AddInMemoryApiScopes(SD.ApiScopes)
    .AddInMemoryClients(SD.Clients)
    .AddAspNetIdentity<ApplicationUser>();

builderIdentityServer.AddDeveloperSigningCredential();


builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddScoped<IProfileService, ProfileService>();


builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();

app.UseAuthorization();


using(var scope = app.Services.CreateScope())
{
    var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
    dbInitializer.Initialize();
}


app.MapRazorPages();

app.Run();
