using DateExample;
using DateExample.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using static System.Formats.Asn1.AsnWriter;

var builder = WebApplication.CreateBuilder(args);
//var builder = CreateWebHostBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
               options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<IdentityUser,IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
//builder.Services.AddIdentity<IdentityUser, IdentityRole>(opts =>
//{
//    opts.Password.RequiredLength = 8;
//    opts.Password.RequireNonAlphanumeric = true;
//    opts.Password.RequireLowercase = false;
//    opts.Password.RequireUppercase = true;
//    opts.Password.RequireDigit = true;
//}).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//               options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddIdentity<IdentityUser, IdentityRole>()
//        .AddEntityFrameworkStores<ApplicationDbContext>()
//.AddDefaultTokenProviders();
builder.Services.AddScoped<MyService>();
//builder.Services.Configure<PasswordOptions>(builder.Configuration.GetSection("PasswordOptions"));
//builder.ConfigureIdentityPasswordOptions();
var serviceProvider = builder.Services.BuildServiceProvider();

// Örneðin, UserManager veya benzeri bir servis kullanabilirsiniz
var userManager = serviceProvider.GetRequiredService<MyService>();

var passwordManager = userManager.GetPasswordOptionsZehra();
builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings
    options.Password.RequireDigit = passwordManager.RequireDigit;
    options.Password.RequiredLength = passwordManager.RequiredLength;
    options.Password.RequireNonAlphanumeric = passwordManager.RequireNonAlphanumeric;
    options.Password.RequireUppercase = passwordManager.RequireUppercase;
    options.Password.RequireLowercase = passwordManager.RequireLowercase;
    options.Password.RequiredUniqueChars = passwordManager.RequiredUniqueChars;
});
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();


//var scope = app.Services.CreateScope();
//var myService = scope.ServiceProvider.GetRequiredService<MyService>();
//myService.FetchData();
//PasswordOptions passwordOptions;
//using (var scope = app.Services.CreateScope())
//{
//    var myService = scope.ServiceProvider.GetRequiredService<MyService>();
//    passwordOptions = myService.GetPasswordOptionsZehra();
//}

var environment = builder.Services;
//ConfigurePasswordOptions(environment);
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//ConfigurePasswordOptions(builder);
//var serviceProvider = app.Services;
//MyService.ConfigurePasswordOptions(serviceProvider);
//MyStaticClass.MyStaticMethod(serviceProvider);
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();



